/*
 * Copyright (c) 2005, 2010, Oracle and/or its affiliates. All rights reserved.
 * DO NOT ALTER OR REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
 */

#include "JavaMonkey.h"
#include "AccessInfo.h"

HWND ourHwnd;
HWND topLevelWindow;
int depth = -1;
FILE *logfile;
HMENU popupMenu;

char theMonkeyClassName[] = "MonkeyWin";
char theAccessInfoClassName[] = "AccessInfoWin";

HWND theMonkeyWindow;
HWND theTreeControlWindow;
HINSTANCE theInstance;
JavaMonkey *theMonkey;
AccessibleNode *theSelectedNode;
AccessibleNode *thePopupNode;
AccessibleContext theSelectedAccessibleContext;
HWND hwndTV;    // handle of tree-view control 

int APIENTRY WinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPSTR     lpCmdLine,
                     int       nCmdShow)
{

    if (logfile == null) {
        logfile = fopen(JAVA_MONKEY_LOG, "w"); // overwrite existing log file
        logString(logfile, "Starting JavaMonkey.exe %s\n", getTimeAndDate());
    }

    theInstance = hInstance;

    // start JavaMonkey
    theMonkey = new JavaMonkey(nCmdShow);

    return 0;
} 

JavaMonkey::JavaMonkey(int nCmdShow) {

    HWND hwnd;
    static char szAppName[] = "JavaMonkey";
    static char szMenuName[] = "MONKEYMENU";
    MSG msg;
    WNDCLASSEX wc;

    // JavaMonkey window
    wc.cbSize = sizeof(wc);
    wc.style = CS_HREDRAW | CS_VREDRAW;
    wc.lpfnWndProc = WinProc;
    wc.cbClsExtra = 0;
    wc.cbWndExtra = 0;
    wc.hInstance = theInstance;
    wc.hIcon = LoadIcon(NULL, IDI_APPLICATION);
    wc.hCursor = LoadCursor(NULL, IDI_APPLICATION);
    wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
    wc.lpszMenuName = szMenuName;
    wc.lpszClassName = szAppName;
    wc.hIconSm = LoadIcon(NULL, IDI_APPLICATION);

    RegisterClassEx(&wc);

    // AccessInfo Window
    wc.cbSize = sizeof(WNDCLASSEX);

    wc.hInstance = theInstance;
    wc.lpszClassName = theAccessInfoClassName;
    wc.lpfnWndProc = (WNDPROC)AccessInfoWindowProc;
    wc.style = 0;

    wc.hIcon = LoadIcon(NULL, IDI_APPLICATION);
    wc.hIconSm = LoadIcon(NULL, IDI_APPLICATION);
    wc.hCursor = LoadCursor(NULL, IDC_ARROW);

    wc.lpszMenuName = "";
    wc.cbClsExtra = 0;
    wc.cbWndExtra = 0;

    wc.hbrBackground = (HBRUSH) GetStockObject(WHITE_BRUSH);

    RegisterClassEx(&wc);

    // create the JavaMonkey window
    hwnd = CreateWindow(szAppName,
                        szAppName,
                        WS_OVERLAPPEDWINDOW,
                        CW_USEDEFAULT,
                        CW_USEDEFAULT,
                        CW_USEDEFAULT,
                        CW_USEDEFAULT,
                        NULL,
                        NULL,
                        theInstance,
                        NULL);

    ourHwnd = hwnd;

    /* Initialize the common controls. */
    INITCOMMONCONTROLSEX cc;
    cc.dwSize = sizeof(INITCOMMONCONTROLSEX);
    cc.dwICC = ICC_TREEVIEW_CLASSES;
    InitCommonControlsEx(&cc); 

    ShowWindow(hwnd, nCmdShow);

    UpdateWindow(hwnd);

    BOOL result = initializeAccessBridge();
    if (result != FALSE) {
        while (GetMessage(&msg, NULL, 0, 0)) {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
        shutdownAccessBridge();
    }
}

/*
 * the Monkey window proc
 */
LRESULT CALLBACK WinProc(HWND hwnd, UINT iMsg, WPARAM wParam, LPARAM lParam) {

    int command;
    short width, height;

    switch(iMsg) {

    case WM_CREATE:
        // create the accessibility tree view
        theTreeControlWindow = CreateATreeView(hwnd);

        // load the popup menu
        popupMenu = LoadMenu(theInstance, "PopupMenu");
        popupMenu = GetSubMenu(popupMenu, 0);
        break;
        
    case WM_CLOSE:
        EndDialog(hwnd, TRUE);
        PostQuitMessage (0);
        break;

    case WM_SIZE:
        width = LOWORD(lParam);
        height = HIWORD(lParam);
        SetWindowPos(theTreeControlWindow, NULL, 0, 0, width, height, 0); 
        return(FALSE);			// let windows finish handling this
        
    case WM_COMMAND:
        command = LOWORD(wParam);
        switch(command) {
            
        case cExitMenuItem:
            EndDialog(hwnd, TRUE);
            PostQuitMessage (0);
            break;
            
        case cRefreshTreeItem:
            // update the accessibility tree
            theMonkey->buildAccessibilityTree();
            break;
            
        case cAPIMenuItem:
            // open a new window with the Accessibility API in it for the
            // selected element in the tree
            if (theSelectedNode != (AccessibleNode *) 0) {
                theSelectedNode->displayAPIWindow();
            }
            break;
            
        case cAPIPopupItem:
            // open a new window with the Accessibility API in it for the
            // element in the tree adjacent to the popup menu
            if (thePopupNode != (AccessibleNode *) 0) {
                thePopupNode->displayAPIWindow();
            }
            break;
            
        }
        break;
        
    case WM_NOTIFY:				// receive tree messages

        NMTREEVIEW *nmptr = (LPNMTREEVIEW) lParam;
        switch (nmptr->hdr.code) {

        case TVN_SELCHANGED:
            // get the selected tree node
            theSelectedNode = (AccessibleNode *) nmptr->itemNew.lParam;	
            break;

        case NM_RCLICK:

            // display a popup menu over the tree node
            POINT p;
            GetCursorPos(&p);
            TrackPopupMenu(popupMenu, 0, p.x, p.y, 0, hwnd, NULL);

            // get the tree node under the popup menu
            TVHITTESTINFO hitinfo;
            ScreenToClient(theTreeControlWindow, &p);
            hitinfo.pt = p;
            HTREEITEM node = TreeView_HitTest(theTreeControlWindow, &hitinfo);

            if (node != null) {
                TVITEMEX tvItem;
                tvItem.hItem = node;
                if (TreeView_GetItem(hwndTV, &tvItem) == TRUE) {
                    thePopupNode = (AccessibleNode *)tvItem.lParam;
                }
            }
            break;
        }
    }
    return DefWindowProc(hwnd, iMsg, wParam, lParam);
}

/*
 * Accessibility information window proc
 */
LRESULT CALLBACK AccessInfoWindowProc(HWND hWnd, UINT message, 
                                    UINT wParam, LONG lParam) {
    short width, height;
    HWND dlgItem;
    
    switch (message) {
    case WM_CREATE:
        RECT rcClient;    // dimensions of client area 
        HWND hwndEdit;    // handle of tree-view control 
        
        // Get the dimensions of the parent window's client area,  
        // and create the edit control. 
        GetClientRect(hWnd, &rcClient); 
        hwndEdit = CreateWindow("Edit", 
                                "",
                                WS_VISIBLE | WS_TABSTOP | WS_CHILD |
                                ES_MULTILINE | ES_AUTOVSCROLL | 
                                ES_READONLY | WS_VSCROLL,
                                0, 0, rcClient.right, rcClient.bottom, 
                                hWnd,
                                (HMENU) cAccessInfoText,
                                theInstance,
                                NULL);
        break;
        
    case WM_CLOSE:
        DestroyWindow(hWnd);
        break;
        
    case WM_SIZE:
        width = LOWORD(lParam);
        height = HIWORD(lParam);
        dlgItem = GetDlgItem(hWnd, cAccessInfoText); 
        SetWindowPos(dlgItem, NULL, 0, 0, width, height, 0); 
        return(FALSE);			// let windows finish handling this
        break;
        
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
    }
    
    return 0;   
}

/**
 * Build a tree (and the treeview control) of all accessible Java components
 *
 */
void JavaMonkey::buildAccessibilityTree() {
    // have MS-Windows call EnumWndProc() with all of the top-level windows
    EnumWindows((WNDENUMPROC) EnumWndProc, NULL);
}

/**
 * Create (and display) the accessible component nodes of a parent AccessibleContext
 *
 */
BOOL CALLBACK EnumWndProc(HWND hwnd, LPARAM lParam) {
    if (IsJavaWindow(hwnd)) {
        long vmID;
        AccessibleContext ac;
        if (GetAccessibleContextFromHWND(hwnd, &vmID, &ac) == TRUE) {
            theMonkey->addComponentNodes(vmID, ac, (AccessibleNode *) NULL, 
                                         hwnd, TVI_ROOT, theTreeControlWindow);
        }
        topLevelWindow = hwnd;
    }
    return(TRUE);
}

// CreateATreeView - creates a tree-view control. 
// Returns the handle of the new control if successful or NULL
//     otherwise. 
// hwndParent - handle of the control's parent window 
HWND CreateATreeView(HWND hwndParent) { 
    RECT rcClient;  // dimensions of client area 
    
    // Get the dimensions of the parent window's client area, and create 
    // the tree-view control. 
    GetClientRect(hwndParent, &rcClient); 
    hwndTV = CreateWindow(WC_TREEVIEW, 
                          "",
                          WS_VISIBLE | WS_TABSTOP | WS_CHILD |
                          TVS_HASLINES | TVS_HASBUTTONS |
                          TVS_LINESATROOT, 
                          0, 0, rcClient.right, rcClient.bottom, 
                          hwndParent,
                          (HMENU) cTreeControl,
                          theInstance,
                          NULL);
    
    return hwndTV; 
} 

/**
 * Create (and display) the accessible component nodes of a parent AccessibleContext
 *
 */
void JavaMonkey::addComponentNodes(long vmID, AccessibleContext context,
                                   AccessibleNode *parent, HWND hwnd, 
                                   HTREEITEM treeNodeParent, HWND treeWnd) {

    AccessibleNode *newNode = new AccessibleNode(vmID, context, parent, hwnd, treeNodeParent);

    AccessibleContextInfo info;
    if (GetAccessibleContextInfo(vmID, context, &info) != FALSE) {
        char s[LINE_BUFSIZE];

        wsprintf(s, "%ls", info.name);
        newNode->setAccessibleName(s);
        wsprintf(s, "%ls", info.role);
        newNode->setAccessibleRole(s);

        wsprintf(s, "%ls [%ls]", info.name, info.role);

        TVITEM tvi;
        tvi.mask = TVIF_PARAM | TVIF_TEXT;
        tvi.pszText = (char *) s; // Accessible name and role
        tvi.cchTextMax = (int)strlen(s);
        tvi.lParam = (long) newNode; // Accessibility information

        TVINSERTSTRUCT tvis;
        tvis.hParent = treeNodeParent;
        tvis.hInsertAfter = TVI_LAST;
        tvis.item = tvi;

        HTREEITEM treeNodeItem = TreeView_InsertItem(treeWnd, &tvis);

        for (int i = 0; i < info.childrenCount; i++) {
            addComponentNodes(vmID, GetAccessibleChildFromContext(vmID, context, i), 
                              newNode, hwnd, treeNodeItem, treeWnd);
        }
    } else {
        char s[LINE_BUFSIZE];
        sprintf(s, "ERROR calling GetAccessibleContextInfo; vmID = %X, context = %X", vmID, context);

        TVITEM tvi;
        tvi.mask = TVIF_PARAM | TVIF_TEXT;	// text and lParam are only valid parts
        tvi.pszText = (char *) s;
        tvi.cchTextMax = (int)strlen(s);
        tvi.lParam = (long) newNode;

        TVINSERTSTRUCT tvis;
        tvis.hParent = treeNodeParent;
        tvis.hInsertAfter = TVI_LAST;	// make tree in order given
        tvis.item = tvi;

        HTREEITEM treeNodeItem = TreeView_InsertItem(treeWnd, &tvis);
    }
}

// -----------------------------

/**
 * Create an AccessibleNode
 *
 */
AccessibleNode::AccessibleNode(long JavaVMID, AccessibleContext context,
                               AccessibleNode *parent, HWND hwnd, 
                               HTREEITEM parentTreeNodeItem) {
    vmID = JavaVMID;
    ac = context;
    parentNode = parent;
    baseHWND = hwnd;
    treeNodeParent = parentTreeNodeItem;

    // setting accessibleName and accessibleRole not done here,
    // in order to minimize calls to the AccessBridge
    // (since such a call is needed to enumerate children)
}

/**
 * Destroy an AccessibleNode
 *
 */
AccessibleNode::~AccessibleNode() {
    ReleaseJavaObject(vmID, ac);
}

/**
 * Set the accessibleName string
 *
 */
void AccessibleNode::setAccessibleName(char *name) {
    strncpy(accessibleName, name, MAX_STRING_SIZE);
}

/**
 * Set the accessibleRole string
 *
 */
void AccessibleNode::setAccessibleRole(char *role) {
    strncpy(accessibleRole, role, SHORT_STRING_SIZE);
}







/**
 * Create an API window to show off the info for this AccessibleContext
 */
BOOL AccessibleNode::displayAPIWindow() {

    HWND apiWindow = CreateWindow(theAccessInfoClassName,
                                  "Java Accessibility API view",
                                  WS_OVERLAPPEDWINDOW,
                                  CW_USEDEFAULT,
                                  CW_USEDEFAULT,
                                  600,
                                  750,
                                  HWND_DESKTOP,
                                  NULL,
                                  theInstance,
                                  (void *) NULL);

    if (!apiWindow) {
        printError("cannot create API window");
        return (FALSE);
    }

    char buffer[HUGE_BUFSIZE];
    buffer[0] = '\0';
    getAccessibleInfo(vmID, ac, buffer, sizeof(buffer));
    displayAndLog(apiWindow, cAccessInfoText, logfile, buffer);														  

    ShowWindow(apiWindow, SW_SHOWNORMAL);
    UpdateWindow(apiWindow); 

    return (TRUE);      
}



