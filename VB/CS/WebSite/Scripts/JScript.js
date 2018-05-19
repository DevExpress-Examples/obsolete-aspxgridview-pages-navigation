function OnInit(s, e) {
    AddKeyboardNavigationTo(s);
}
function AddKeyboardNavigationTo(gridViewInstance) {
    ASPxClientUtils.AttachEventToElement(document, "keydown",
            function(evt) {
                return OnDataViewKeyDown(evt, gridViewInstance);
            });
}
function OnDataViewKeyDown(evt, gridViewInstance) {
    if (typeof (event) != "undefined" && event != null)
        evt = event;
    if (NeedProcessDataViewKeyDown(evt) && !gridViewInstance.InCallback()) {
        if (evt.keyCode == ASPxKey.Left /*37-Left Arrow*/) {
            if (gridViewInstance.cpPageIndex > 0)
                gridViewInstance.PerformCallback('Prev');
            return ASPxClientUtils.PreventEvent(evt);
        } else if (evt.keyCode == ASPxKey.Right /*39-Right Arrow*/ && gridViewInstance.cpPageIndex < gridViewInstance.cpPageCount - 1) {
            gridViewInstance.PerformCallback('Next');
            return ASPxClientUtils.PreventEvent(evt);
        }
    }
}
function NeedProcessDataViewKeyDown(evt) {
    var evtSrc = ASPxClientUtils.GetEventSource(evt);
    if (evtSrc.tagName == "INPUT")
        return evtSrc.type != "text" && evtSrc.type != "password";
    else
        return evtSrc.tagName != "TEXTAREA";
}

