/*
 * Copyright (c) 2005, 2010, Oracle and/or its affiliates. All rights reserved.
 * DO NOT ALTER OR REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
 */

/* 
 * A sample Assistive Technology which queries the JavaVM (if any) underneath
 * the mouse pointer to get the Java Accessibility information available
 * for the Java UI object underneath the mouse, using the Java 
 * Accessibility Bridge, AccessBridge.DLL
 */

/*
 TO DO

 - update copyright
 - add logging to JavaFerret docs
 - add /NO_LOGGING flag to JavaFerret docs

 */

#include <windows.h>   // includes basic windows functionality
#include <jni.h>

#include "ferretResource.h"
#include "AccessBridgeCalls.h"
#include "AccessBridgeCallbacks.h"

#include <stdio.h>
#include <time.h>
#include <string.h>

#include "JavaFerret.h"
#include "AccessInfo.h"

#define TIMER_ID 1
#define DISPLAY_INFO_MESSAGE WM_USER+1
#define DISPLAY_HWND_INFO_MESSAGE WM_USER+2

HWND theDialogWindow;
HINSTANCE theInstance;
BOOL theAccessBridgeLoadedFlag;

HHOOK prevKbdHook;
HHOOK prevMouseHook;

BOOL updateMouse;
BOOL updateF1;
BOOL updateF2;

BOOL trackMouse;
BOOL trackFocus;
BOOL trackCaret;
BOOL trackShutdown;

BOOL trackMenuSelected;
BOOL trackMenuDeselected;
BOOL trackMenuCanceled;

BOOL trackPopupVisible;
BOOL trackPopupInvisible;
BOOL trackPopupCanceled;

//BOOL trackPropertyChange;

BOOL trackPropertyNameChange;
BOOL trackPropertyDescriptionChange;
BOOL trackPropertyStateChange;
BOOL trackPropertyValueChange;
BOOL trackPropertySelectionChange;
BOOL trackPropertyTextChange;
BOOL trackPropertyCaretChange;
BOOL trackPropertyVisibleDataChange;
BOOL trackPropertyChildChange;
BOOL trackPropertyActiveDescendentChange;
BOOL trackPropertyTableModelChange;


FILE *logfile = NULL;

/**
 * WinMain
 *
 */
int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR lpCmdLine, int nShowCmd) {
    MSG msg;

    theInstance = hInst;

    updateF1 = FALSE;
    updateF2 = FALSE;
    updateMouse = FALSE;

    trackMouse = FALSE;
    trackShutdown = FALSE;
    trackFocus = FALSE;
    trackCaret = FALSE;
    trackMenuSelected = FALSE;
    trackMenuDeselected = FALSE;
    trackMenuCanceled = FALSE;
    trackPopupVisible = FALSE;
    trackPopupInvisible = FALSE;
    trackPopupCanceled = FALSE;

    trackPropertyNameChange = FALSE;
    trackPropertyDescriptionChange = FALSE;
    trackPropertyStateChange = FALSE;
    trackPropertyValueChange = FALSE;
    trackPropertySelectionChange = FALSE;
    trackPropertyTextChange = FALSE;
    trackPropertyCaretChange = FALSE;
    trackPropertyVisibleDataChange = FALSE;
    trackPropertyChildChange = FALSE;
    trackPropertyActiveDescendentChange = FALSE;
    trackPropertyTableModelChange = FALSE;


    theAccessBridgeLoadedFlag = FALSE;


    if (InitWindow(hInst)) {
        if (initializeAccessBridge() == TRUE) {
            theAccessBridgeLoadedFlag = TRUE;
            while (GetMessage(&msg, NULL, 0, 0)) {
                TranslateMessage(&msg);
                DispatchMessage(&msg);
            }
            if (theAccessBridgeLoadedFlag == TRUE) {
                shutdownAccessBridge();
            }
        }
    }
    return(0);
}

char szAppName [] = "FERRETWINDOW";

/**
 * Real(tm) MS-Windows window initialization
 *
 */
BOOL InitWindow (HANDLE hInstance) {
    theDialogWindow = CreateDialog ((struct HINSTANCE__ *)hInstance,
                                    szAppName, 
                                    NULL, 
                                    (DLGPROC)FerretDialogProc);

    // If window could not be created, return "failure".
    if (!theDialogWindow)
        return (FALSE);

    if (logfile == null) {
        logfile = fopen(JAVA_FERRET_LOG, "w"); // overwrite existing log file
        logString(logfile, "Starting JavaFerret.exe %s\n", getTimeAndDate());
    }
	
    // Make the window visible, update its client area, & return "success".
    SetWindowText (theDialogWindow, "Java Ferret");
    ShowWindow (theDialogWindow, SW_SHOWNORMAL);
    UpdateWindow (theDialogWindow); 

    return (TRUE);      
}

/**
 * Display Accessible information about the object under the mouse
 */
void displayAccessibleInfo(long vmID, AccessibleContext ac, int x, int y) {
    char buffer[HUGE_BUFSIZE];

    getAccessibleInfo(vmID, ac, x, y, buffer, (int)(sizeof(buffer)));
    displayAndLog(theDialogWindow, cFerretText, logfile, (char *)buffer);
}

/**
 * Display Java event info
 */
void displayJavaEvent(long vmID, AccessibleContext ac, char *announcement) {
    char buffer[HUGE_BUFSIZE];
    char *bufOffset;

    strncpy(buffer, announcement, sizeof(buffer));

    bufOffset = (char *) (buffer + strlen(buffer));
    getAccessibleInfo(vmID, ac, -1, -1, bufOffset, (int)(sizeof(buffer) - strlen(buffer)));
    displayAndLog(theDialogWindow, cFerretText, logfile, (char *)buffer);
}


/**
 * Display Accessible propertyChange event info
 */
void displayAccessiblePropertyChange(long vmID, AccessibleContext ac,
                                     char *announcement) {
    char buffer[HUGE_BUFSIZE];
    char *bufOffset;

    strncpy(buffer, announcement, sizeof(buffer));

    bufOffset = (char *) (buffer + strlen(buffer));
    getAccessibleInfo(vmID, ac, -1, -1, bufOffset, (int)(sizeof(buffer) - strlen(buffer)));
    displayAndLog(theDialogWindow, cFerretText, logfile, (char *)buffer);
}


/**
 * Update display under mouse when it moves
 */
void echoMouseObject() {
    long vmID;
    AccessibleContext acParent;
    AccessibleContext ac;
    POINT p;
    HWND hwnd;
    RECT windowRect;

    GetCursorPos(&p);
    hwnd = WindowFromPoint(p);
    if (GetAccessibleContextFromHWND(hwnd, &vmID, &acParent)) {
        GetWindowRect(hwnd, &windowRect);
        // send the point in global coordinates; Java will handle it!
        if (GetAccessibleContextAt(vmID, acParent, (jint) p.x, (jint) p.y, &ac)) {
            displayAccessibleInfo(vmID, ac, p.x, p.y);		// can handle null
            ReleaseJavaObject(vmID, ac);
        }
    }
}


/**
 * Update display under HWND the mouse is in
 */
void echoMouseHWNDObject() {
    long vmID;
    AccessibleContext ac;
    POINT p;
    HWND hwnd;

    GetCursorPos(&p);
    hwnd = WindowFromPoint(p); 

    if (GetAccessibleContextFromHWND(hwnd, &vmID, &ac)) {
        displayAccessibleInfo(vmID, ac, 0, 0);		// can handle null
        ReleaseJavaObject(vmID, ac);
    }
}

/**
 * Display Accessible information about the object that has focus in 
 * the topmost Java HWND
 *
 */
void displayFocusedObject() {
    HWND hWnd;
    long vmID;
    AccessibleContext ac;

    hWnd = GetTopWindow(NULL);
    while (hWnd != NULL) {
        if (IsJavaWindow(hWnd)) {
            if (GetAccessibleContextWithFocus(hWnd, &vmID, &ac) == TRUE) {
                displayAccessibleInfo(vmID, ac, 0, 0);
            	ReleaseJavaObject(vmID, ac);
            }
            return;
        } else {
            hWnd = GetNextWindow(hWnd, GW_HWNDNEXT);
        }
    }
}

/*
 * Handle notification of the Java application shutting down
 */
void HandleJavaShutdown(long vmID) {
    char s[1024];
    wsprintf(s, "Java VM 0x%X terminated\r\n\r\n", vmID);

    displayJavaEvent(vmID, null, s); // intentially passing null AccessibleContext
    displayAndLog(theDialogWindow, cFerretText, logfile, (char *)s);
}

/**
 * Handle a FocusGained event
 */
void HandleJavaFocusGained(long vmID, FocusEvent event, AccessibleContext ac) {

    char s[1024];
    wsprintf(s, "FocusGained\r\n\r\n");

    if (ac != (AccessibleContext) 0) {
        displayJavaEvent(vmID, ac, s);
    }

    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a FocusLost event
 */
void HandleJavaFocusLost(long vmID, FocusEvent event, AccessibleContext ac) {

    // NOTE: calling GetAccessibleContextWithFocus() after a FocusLost event
    //       would result in a null AccessibleContext being returned, since
    //       at that point, no object has the focus.  If the topmost window
    //       does not belong to a JavaVM, then no component within a JavaVM
    //       will have the focus (and again, GetAccessibleContextWithFocus()
    //       will return a null AccessibleContext).  You should always get
    //       a FocusLost event when a window not belonging to a JavaVM becomes
    //       topmost.

    char s[1024];
    wsprintf(s, "FocusLost\r\n\r\n");

    if (ac != (AccessibleContext) 0) {
        displayJavaEvent(vmID, ac, s);
    }
    /*
    if (ac != (AccessibleContext) 0) {
        displayAccessibleInfo(vmID, ac, 0, 0);
    }
    */
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a CaretUpdate event
 */
void HandleJavaCaretUpdate(long vmID, CaretEvent event, AccessibleContext ac) {
    if (ac != (AccessibleContext) 0) {
        displayAccessibleInfo(vmID, ac, 0, 0);
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a MouseClicked event
 */
void HandleMouseClicked(long vmID, MouseEvent event, AccessibleContext ac) {
    if (ac != (AccessibleContext) 0) {
        displayAccessibleInfo(vmID, ac, 0, 0);
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a MouseEntered event
 */
void HandleMouseEntered(long vmID, MouseEvent event, AccessibleContext ac) {
    if (ac != (AccessibleContext) 0) {
        displayAccessibleInfo(vmID, ac, 0, 0);
    }

    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a MouseExited event
 */
void HandleMouseExited(long vmID, MouseEvent event, AccessibleContext ac) {
    if (ac != (AccessibleContext) 0) {
        displayAccessibleInfo(vmID, ac, 0, 0);
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a MousePressed event
 */
void HandleMousePressed(long vmID, MouseEvent event, AccessibleContext ac) {
    if (ac != (AccessibleContext) 0) {
        displayAccessibleInfo(vmID, ac, 0, 0);
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a MouseReleased event
 */
void HandleMouseReleased(long vmID, MouseEvent event, AccessibleContext ac) {
    if (ac != (AccessibleContext) 0) {
        displayAccessibleInfo(vmID, ac, 0, 0);
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a MenuCanceled event
 */
void HandleMenuCanceled(long vmID, MenuEvent event, AccessibleContext ac) {
    if (ac != (AccessibleContext) 0) {
        displayAccessibleInfo(vmID, ac, 0, 0);
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a MenuDeselected event
 */
void HandleMenuDeselected(long vmID, MenuEvent event, AccessibleContext ac) {
    if (ac != (AccessibleContext) 0) {
        displayAccessibleInfo(vmID, ac, 0, 0);
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a MenuSelected event
 */
void HandleMenuSelected(long vmID, MenuEvent event, AccessibleContext ac) {
    if (ac != (AccessibleContext) 0) {
        displayAccessibleInfo(vmID, ac, 0, 0);
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a PopupMenuCanceled event
 */
void HandlePopupMenuCanceled(long vmID, MenuEvent event, AccessibleContext ac) {
    if (ac != (AccessibleContext) 0) {
        displayAccessibleInfo(vmID, ac, 0, 0);
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a PopupMenuWillBecomeInvisible event
 */
void HandlePopupMenuWillBecomeInvisible(long vmID, MenuEvent event, AccessibleContext ac) {
    if (ac != (AccessibleContext) 0) {
        displayAccessibleInfo(vmID, ac, 0, 0);
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a PopupMenuWillBecomeVisible event
 */
void HandlePopupMenuWillBecomeVisible(long vmID, MenuEvent event, AccessibleContext ac) {
    if (ac != (AccessibleContext) 0) {
        displayAccessibleInfo(vmID, ac, 0, 0);
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}




/**
 * Handle a HandlePropertyNameChange event
 */
void HandlePropertyNameChange(long vmID, PropertyChangeEvent event, AccessibleContext ac,
                              wchar_t *oldName, wchar_t *newName) {
    char s[1024];
    wsprintf(s, "Name changed event: old = %ls; new = %ls\r\n\r\n", oldName, newName);

    if (ac != (AccessibleContext) 0) {
        displayAccessiblePropertyChange(vmID, ac, s);
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a HandlePropertyDescriptionChange event
 */
void HandlePropertyDescriptionChange(long vmID, PropertyChangeEvent event, AccessibleContext ac,
                                     wchar_t *oldDescription, wchar_t *newDescription) {
    char s[1024];
    wsprintf(s, "Description changed event: old = %ls; new = %ls\r\n\r\n", oldDescription, newDescription);

    if (ac != (AccessibleContext) 0) {
        displayAccessiblePropertyChange(vmID, ac, s);
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a HandlePropertyStateChange event
 */
void HandlePropertyStateChange(long vmID, PropertyChangeEvent event, AccessibleContext ac,
                               wchar_t *oldState, wchar_t *newState) {
    char s[1024];
    wsprintf(s, "State changed event: old = %ls; new = %ls\r\n\r\n", oldState, newState);

    if (ac != (AccessibleContext) 0) {
        displayAccessiblePropertyChange(vmID, ac, s);
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a HandlePropertyValueChange event
 */
void HandlePropertyValueChange(long vmID, PropertyChangeEvent event, AccessibleContext ac,
                               wchar_t *oldValue, wchar_t *newValue) {
    char s[1024];
    wsprintf(s, "Value changed event: old = %ls; new = %ls\r\n\r\n", oldValue, newValue);

    if (ac != (AccessibleContext) 0) {
        displayAccessiblePropertyChange(vmID, ac, s);
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a HandlePropertySelectionChange event
 */
void HandlePropertySelectionChange(long vmID, PropertyChangeEvent event, AccessibleContext ac) {
    if (ac != (AccessibleContext) 0) {
        displayAccessiblePropertyChange(vmID, ac, "Selection changed event\r\n\r\n");
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a HandlePropertyTextChange event
 */
void HandlePropertyTextChange(long vmID, PropertyChangeEvent event, AccessibleContext ac) {
    if (ac != (AccessibleContext) 0) {
        displayAccessiblePropertyChange(vmID, ac, "Text changed event\r\n\r\n");
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a HandlePropertyCaretChange event
 */
void HandlePropertyCaretChange(long vmID, PropertyChangeEvent event, AccessibleContext ac,
                               int oldPosition, int newPosition) {
    char s[1024];

    wsprintf(s, "Caret changed event: oldPosition = %d; newPosition = %d\r\n\r\n", oldPosition, newPosition);

    if (ac != (AccessibleContext) 0) {
        displayAccessiblePropertyChange(vmID, ac, s);
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a HandlePropertyVisibleDataChange event
 */
void HandlePropertyVisibleDataChange(long vmID, PropertyChangeEvent event, AccessibleContext ac) {
    if (ac != (AccessibleContext) 0) {
        displayAccessiblePropertyChange(vmID, ac, "VisibleData changed event\r\n\r\n");
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}

/**
 * Handle a HandlePropertyChildChange event
 */
void HandlePropertyChildChange(long vmID, PropertyChangeEvent event, AccessibleContext ac,
                               JOBJECT64 oldChild, JOBJECT64 newChild) {
    char buffer[HUGE_BUFSIZE];
    char *bufOffset;

    sprintf(buffer, "Child property changed event:\r\n=======================\r\n\r\n");

    if (oldChild != 0) {
        strncat(buffer, "Old Accessible Child info:\r\n\r\n", sizeof(buffer));
        bufOffset = (char *) (buffer + strlen(buffer));
        getAccessibleInfo(vmID, oldChild, 0, 0, bufOffset, (int)(sizeof(buffer) - strlen(buffer)));
        strncat(buffer, "\r\n\r\n", sizeof(buffer));
    }

    if (newChild != 0) {
        strncat(buffer, "New Accessible Child info:\r\n\r\n", sizeof(buffer));
        bufOffset = (char *) (buffer + strlen(buffer));
        getAccessibleInfo(vmID, newChild, 0, 0, bufOffset, (int)(sizeof(buffer) - strlen(buffer)));
        strncat(buffer, "\r\n\r\n", sizeof(buffer));
    }
    
    if (ac != (AccessibleContext) 0) {
        displayAccessiblePropertyChange(vmID, ac, buffer);
    }

    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, oldChild);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, newChild);	// must always release, to stave off memory leaks
}

/**
 * Handle a HandlePropertyActiveDescendentChange event
 */
void HandlePropertyActiveDescendentChange(long vmID, PropertyChangeEvent event, 
                                          AccessibleContext ac, 
                                          JOBJECT64 oldActiveDescendent,
                                          JOBJECT64 newActiveDescendent) {
    char buffer[HUGE_BUFSIZE];

    sprintf(buffer, "ActiveDescendent property changed event:\r\n=======================\r\n\r\n");

#ifdef _notdef
    char *bufOffset;
    if (oldActiveDescendent != 0) {
        strncat(buffer, "Old Accessible ActiveDescendent info:\r\n\r\n", sizeof(buffer));
        bufOffset = (char *) (buffer + strlen(buffer));
        getAccessibleInfo(vmID, oldActiveDescendent, 0, 0, bufOffset, (int)(sizeof(buffer) - strlen(buffer)));
        strncat(buffer, "\r\n\r\n", sizeof(buffer));
    }

    if (newActiveDescendent != 0) {
        strncat(buffer, "New Accessible ActiveDescendent info:\r\n\r\n", sizeof(buffer));
        bufOffset = (char *) (buffer + strlen(buffer));
        getAccessibleInfo(vmID, newActiveDescendent, 0, 0, bufOffset, (int)(sizeof(buffer) - strlen(buffer)));
        strncat(buffer, "\r\n\r\n", sizeof(buffer));
    }
#endif _notdef

        
    if (newActiveDescendent != (AccessibleContext) 0) {
        displayAccessiblePropertyChange(vmID, newActiveDescendent, buffer);
    }

    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, oldActiveDescendent);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, newActiveDescendent);	// must always release, to stave off memory leaks
}


/**
 * Handle a HandlePropertyTableModelChange event
 */
void HandlePropertyTableModelChange(long vmID, PropertyChangeEvent event, 
                                    AccessibleContext ac, 
                                    wchar_t *oldValue, wchar_t *newValue) {

    char s[1024];
    wsprintf(s, "Table Model Change: old = %ls; new = %ls\r\n\r\n", oldValue, newValue);

    if (ac != (AccessibleContext) 0) {
        displayAccessiblePropertyChange(vmID, ac, s);
    }
    ReleaseJavaObject(vmID, ac);	// must always release, to stave off memory leaks
    ReleaseJavaObject(vmID, event);	// must always release, to stave off memory leaks
}



#define DOWN_UP_FLAG 1<<31

void CALLBACK TimerProc(HWND hWnd, UINT uTimerMsg, UINT uTimerID, DWORD dwTime) {
    // when mouse settles from movement
    KillTimer(hWnd, uTimerID);
    if (updateMouse == TRUE) {
        PostMessage(theDialogWindow, DISPLAY_INFO_MESSAGE, 0, 0);
    }
}

LRESULT CALLBACK KeyboardProc(int code, WPARAM wParam, LPARAM lParam) {
    // on mouse-up of F1
    if (code < 0) {
        CallNextHookEx(prevKbdHook, code, wParam, lParam);
    } else if (wParam == VK_F1 && lParam & DOWN_UP_FLAG) {
        PostMessage(theDialogWindow, DISPLAY_INFO_MESSAGE, wParam, lParam);
    } else if (wParam == VK_F2 && lParam & DOWN_UP_FLAG) {
        PostMessage(theDialogWindow, DISPLAY_HWND_INFO_MESSAGE, wParam, lParam);
    }
    return 0;
}

LRESULT CALLBACK MouseProc(int code, WPARAM wParam, LPARAM lParam) {
    // when mouse settles from movement
    if (code < 0) {
        CallNextHookEx(prevMouseHook, code, wParam, lParam);
    } else {
        // reset the timer every time the mouse moves
        KillTimer(theDialogWindow, TIMER_ID);
        SetTimer(theDialogWindow, TIMER_ID, 1000, (TIMERPROC)TimerProc);
    }
    return 0;
}

void exitJavaFerret(HWND hWnd) {
    EndDialog(hWnd, TRUE);
    PostQuitMessage (0);
}

#define INSTALL_EVENT_LISTENER(toggleVal, setFP, handler)   \
    if (toggleVal) {                                        \
        setFP(handler);                                     \
    }

void reinstallEventListeners() {
    INSTALL_EVENT_LISTENER(trackMouse, SetMouseEntered, HandleMouseEntered);
    INSTALL_EVENT_LISTENER(trackShutdown, SetJavaShutdown, HandleJavaShutdown);
    INSTALL_EVENT_LISTENER(trackFocus, SetFocusGained, HandleJavaFocusGained);
    INSTALL_EVENT_LISTENER(trackFocus, SetFocusGained, HandleJavaFocusGained);
    INSTALL_EVENT_LISTENER(trackCaret, SetCaretUpdate, HandleJavaCaretUpdate);

    INSTALL_EVENT_LISTENER(trackMenuSelected, SetMenuSelected, HandleMenuSelected);
    INSTALL_EVENT_LISTENER(trackMenuDeselected, SetMenuDeselected, HandleMenuDeselected);
    INSTALL_EVENT_LISTENER(trackMenuCanceled, SetMenuCanceled, HandleMenuCanceled);

    INSTALL_EVENT_LISTENER(trackPopupVisible, SetPopupMenuWillBecomeVisible, HandlePopupMenuWillBecomeVisible);
    INSTALL_EVENT_LISTENER(trackPopupInvisible, SetPopupMenuWillBecomeInvisible, HandlePopupMenuWillBecomeInvisible);
    INSTALL_EVENT_LISTENER(trackPopupCanceled, SetPopupMenuCanceled, HandlePopupMenuCanceled);

    INSTALL_EVENT_LISTENER(trackPropertyNameChange, SetPropertyNameChange, HandlePropertyNameChange);
    INSTALL_EVENT_LISTENER(trackPropertyDescriptionChange, SetPropertyDescriptionChange, HandlePropertyDescriptionChange);
    INSTALL_EVENT_LISTENER(trackPropertyStateChange, SetPropertyStateChange, HandlePropertyStateChange);
    INSTALL_EVENT_LISTENER(trackPropertyValueChange, SetPropertyValueChange, HandlePropertyValueChange);
    INSTALL_EVENT_LISTENER(trackPropertySelectionChange, SetPropertySelectionChange, HandlePropertySelectionChange);
    INSTALL_EVENT_LISTENER(trackPropertyTextChange, SetPropertyTextChange, HandlePropertyTextChange);
    INSTALL_EVENT_LISTENER(trackPropertyCaretChange, SetPropertyCaretChange, HandlePropertyCaretChange);
    INSTALL_EVENT_LISTENER(trackPropertyVisibleDataChange, SetPropertyVisibleDataChange, HandlePropertyVisibleDataChange);
    INSTALL_EVENT_LISTENER(trackPropertyChildChange, SetPropertyChildChange, HandlePropertyChildChange);
    INSTALL_EVENT_LISTENER(trackPropertyActiveDescendentChange, SetPropertyActiveDescendentChange, HandlePropertyActiveDescendentChange);
    INSTALL_EVENT_LISTENER(trackPropertyTableModelChange, SetPropertyTableModelChange, HandlePropertyTableModelChange);
}


#define TRACK_EVENT_TOGGLE(menuItem, toggleVal, setFP, handler)	\
	case menuItem:												\
		menu = GetMenu(hWnd);									\
		if (toggleVal) {										\
			toggleVal = FALSE;									\
			CheckMenuItem(menu, menuItem,						\
						  MF_BYCOMMAND | MF_UNCHECKED);			\
			setFP(NULL);										\
		} else {												\
			toggleVal = TRUE;									\
			CheckMenuItem(menu, menuItem,						\
						  MF_BYCOMMAND | MF_CHECKED);			\
			setFP(handler);										\
		}														\
		return(TRUE)


BOOL APIENTRY FerretDialogProc (HWND hWnd, UINT message, UINT wParam, LONG lParam) {
    int command;
    short width, height;
    HWND dlgItem;
    HMENU menu;

    switch (message) {

    case WM_CREATE:
        return 0;

    case WM_INITDIALOG:
        CheckMenuItem(GetMenu(hWnd), cAccessBridgeDLLLoaded, MF_BYCOMMAND | MF_CHECKED);
        return(TRUE);

    case WM_CLOSE:
        exitJavaFerret(hWnd);
        return(TRUE);
        break;
	
    case WM_SIZE:
        width = LOWORD(lParam);
        height = HIWORD(lParam);
        dlgItem = GetDlgItem(theDialogWindow, cFerretText); 
        SetWindowPos(dlgItem, NULL, 0, 0, width, height, 0); 
        return(FALSE);			// let windows finish handling this
        break;
	
    case WM_COMMAND:
        command = LOWORD(wParam);

        switch(command) {
        case cAccessBridgeDLLLoaded:    // toggle; unload or load AccessBridge
            if (theAccessBridgeLoadedFlag) {
                shutdownAccessBridge();
                theAccessBridgeLoadedFlag = FALSE;
                CheckMenuItem(GetMenu(hWnd), cAccessBridgeDLLLoaded, MF_BYCOMMAND | MF_UNCHECKED);
            } else {
                theAccessBridgeLoadedFlag = initializeAccessBridge();
                if (theAccessBridgeLoadedFlag) {
                    CheckMenuItem(GetMenu(hWnd), cAccessBridgeDLLLoaded, MF_BYCOMMAND | MF_CHECKED);
                    reinstallEventListeners();
                }
            }
            return(TRUE);

        case cExitMenuItem:
            exitJavaFerret(hWnd);
            return(TRUE);
            
            TRACK_EVENT_TOGGLE(cTrackMouseMenuItem, trackMouse, SetMouseEntered, HandleMouseEntered);
            TRACK_EVENT_TOGGLE(cTrackShutdownMenuItem, trackShutdown, SetJavaShutdown, HandleJavaShutdown);
            TRACK_EVENT_TOGGLE(cTrackFocusMenuItem, trackFocus, SetFocusGained, HandleJavaFocusGained);
            TRACK_EVENT_TOGGLE(cTrackCaretMenuItem, trackCaret, SetCaretUpdate, HandleJavaCaretUpdate);
            
            TRACK_EVENT_TOGGLE(cTrackMenuSelectedMenuItem, trackMenuSelected, SetMenuSelected, HandleMenuSelected);
            TRACK_EVENT_TOGGLE(cTrackMenuDeselectedMenuItem, trackMenuDeselected, SetMenuDeselected, HandleMenuDeselected);
            TRACK_EVENT_TOGGLE(cTrackMenuCanceledItem, trackMenuCanceled, SetMenuCanceled, HandleMenuCanceled);
            
            TRACK_EVENT_TOGGLE(cTrackPopupBecomeVisibleMenuItem, trackPopupVisible, SetPopupMenuWillBecomeVisible, HandlePopupMenuWillBecomeVisible);
            TRACK_EVENT_TOGGLE(cTrackPopupBecomeInvisibleMenuItem, trackPopupInvisible, SetPopupMenuWillBecomeInvisible, HandlePopupMenuWillBecomeInvisible);
            TRACK_EVENT_TOGGLE(cTrackPopupCanceledItem, trackPopupCanceled, SetPopupMenuCanceled, HandlePopupMenuCanceled);
            
            TRACK_EVENT_TOGGLE(cTrackPropertyNameItem, trackPropertyNameChange, SetPropertyNameChange, HandlePropertyNameChange);
            TRACK_EVENT_TOGGLE(cTrackPropertyDescriptionItem, trackPropertyDescriptionChange, SetPropertyDescriptionChange, HandlePropertyDescriptionChange);
            TRACK_EVENT_TOGGLE(cTrackPropertyStateItem, trackPropertyStateChange, SetPropertyStateChange, HandlePropertyStateChange);
            TRACK_EVENT_TOGGLE(cTrackPropertyValueItem, trackPropertyValueChange, SetPropertyValueChange, HandlePropertyValueChange);
            TRACK_EVENT_TOGGLE(cTrackPropertySelectionItem, trackPropertySelectionChange, SetPropertySelectionChange, HandlePropertySelectionChange);
            TRACK_EVENT_TOGGLE(cTrackPropertyTextItem, trackPropertyTextChange, SetPropertyTextChange, HandlePropertyTextChange);
            TRACK_EVENT_TOGGLE(cTrackPropertyCaretItem, trackPropertyCaretChange, SetPropertyCaretChange, HandlePropertyCaretChange);
            TRACK_EVENT_TOGGLE(cTrackPropertyVisibleDataItem, trackPropertyVisibleDataChange, SetPropertyVisibleDataChange, HandlePropertyVisibleDataChange);
            TRACK_EVENT_TOGGLE(cTrackPropertyChildItem, trackPropertyChildChange, SetPropertyChildChange, HandlePropertyChildChange);
            TRACK_EVENT_TOGGLE(cTrackPropertyActiveDescendentItem, trackPropertyActiveDescendentChange, SetPropertyActiveDescendentChange, HandlePropertyActiveDescendentChange);
            TRACK_EVENT_TOGGLE(cTrackPropertyTableModelChangeItem, trackPropertyTableModelChange, SetPropertyTableModelChange, HandlePropertyTableModelChange);
            
        case cUpdateFromMouseMenuItem:
            menu = GetMenu(hWnd);
            if (updateMouse) {
                updateMouse = FALSE;
                CheckMenuItem(menu, cUpdateFromMouseMenuItem, 
                              MF_BYCOMMAND | MF_UNCHECKED);
                UnhookWindowsHookEx((HHOOK)MouseProc);
                KillTimer(hWnd, TIMER_ID);
            } else {
                updateMouse = TRUE;
                CheckMenuItem(menu, cUpdateFromMouseMenuItem, 
                              MF_BYCOMMAND | MF_CHECKED);
                prevMouseHook = SetWindowsHookEx(WH_MOUSE, MouseProc, theInstance, 0);
            }
            return(TRUE);

        case cUpdateWithF1Item:
            menu = GetMenu(hWnd);
            if (updateF1) {
                updateF1 = FALSE;
                CheckMenuItem(menu, cUpdateWithF1Item,  
                              MF_BYCOMMAND | MFS_UNCHECKED);
                UnhookWindowsHookEx((HHOOK)KeyboardProc);
            } else {
                updateF1 = TRUE;
                CheckMenuItem(menu, cUpdateWithF1Item,  
                              MF_BYCOMMAND | MFS_CHECKED);
                prevKbdHook = SetWindowsHookEx(WH_KEYBOARD, KeyboardProc, theInstance, 0);
            }
            return(TRUE);

        case cUpdateWithF2Item:
            menu = GetMenu(hWnd);
            if (updateF2) {
                updateF2 = FALSE;
                CheckMenuItem(menu, cUpdateWithF2Item,  
                              MF_BYCOMMAND | MFS_UNCHECKED);
                UnhookWindowsHookEx((HHOOK)KeyboardProc);
            } else {
                updateF2 = TRUE;
                CheckMenuItem(menu, cUpdateWithF2Item,  
                              MF_BYCOMMAND | MFS_CHECKED);
                prevKbdHook = SetWindowsHookEx(WH_KEYBOARD, KeyboardProc, theInstance, 0);
            }
            return(TRUE);

        }
        break;

    case DISPLAY_INFO_MESSAGE:
        echoMouseObject();
        break;

    case DISPLAY_HWND_INFO_MESSAGE:
        echoMouseHWNDObject();
        break;
    }

    return (FALSE);   
}
