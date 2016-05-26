            arguments = "BODY","HEAD","HTML","TD","UL","TABLE","H1","H2","H3","AREA","DIV","SPAN","FORM","EM","STRONG","DFN","CODE","SAMP","KBD","VAR"
            
            if (null == document.flagRecorgingHooks && 1 !== document.flagRecorgingHooks) {
                //document.title = "INSERT";
                    function setHooks(excludeTags) {
                        window.excludeList = new Array(excludeTags); 
                        window.recordings = new Array();
                        var scriptElement = document.createElement('script');
                        scriptElement.type = 'text/javascript';
                        scriptElement.innerHTML = '<!--\r\nfunction reportElement(event) { try { var elt = document.elementFromPoint(event.clientX, event.clientY); if (-1 != window.excludeList.indexOf(elt.tagName)) { return; } if (0 < window.recordings.length && elt === window.recordings[window.recordings.length - 1]) { return; } window.recordings.push(elt); } catch (err) {  } } \r\n//-->';
                        document.getElementsByTagName("head")[0].appendChild(scriptElement);
                //        document.getElementsByTagName("html")[0].setAttribute("onmouseover", "reportElement(event)");
                        document.getElementsByTagName("html")[0].setAttribute("onmousemove", "reportElement(event)");
                        var scriptElement = document.createElement('script');
                        scriptElement.type = 'text/javascript';
                        scriptElement.innerHTML = '<!--\r\nfunction reportClick(event) { try { var elt = document.elementFromPoint(event.clientX, event.clientY); if (-1 != window.excludeList.indexOf(elt.tagName)) { return; } window.recordings.push(window.elementClicked); } catch (err) {  } } \r\n//-->';
                        document.getElementsByTagName("head")[0].appendChild(scriptElement);
                        document.getElementsByTagName("html")[0].setAttribute("onclick", "reportClick(event)");
                        var scriptElement = document.createElement('script');
                        scriptElement.type = 'text/javascript';
                        scriptElement.innerHTML = '<!--\r\nfunction cleanRecordings() { window.recordings = null; setHooks(); } \r\n//-->';
                        document.getElementsByTagName("head")[0].appendChild(scriptElement);
                        document.getElementsByTagName("html")[0].setAttribute("onload", "cleanRecordings()");
                
                        window.elementClicked = document.getElementsByTagName('html')[0].appendChild(document.createElement("recClicked"));
                        
                        document.flagRecorgingHooks = 1;
                    }
                    setHooks(arguments[0]);
                }
/*
            if (null != window.recordings && 0 < window.recordings.length) {
                var collected = window.recordings.slice(0, window.recordings.length - 1);
                window.recordings.splice(0, window.recordings.length - 1);
                return collected;
            }
        */
            window.recordings = new Array();
        
            document.getElementsByTagName("html")[0].setAttribute("onmouseover", "");
        
            if ((null == document.flagRecorgingHooks) || (1 !== document.flagRecorgingHooks) || (null == window.recordings)) {
                "0";
            } else {
                "1";
            }
