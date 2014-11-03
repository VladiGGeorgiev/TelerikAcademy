function checkBrowserType(event, arguments) {
	var currentWindow = window;
	var currentBrowser = currentWindow.navigator.appCodeName;
	var isMozillaBrowser = currentBrowser == "Mozilla";

	if(isMozillaBrowser) {
		alert("The browser is Mozilla");  
	} else {
		alert("The browser is NOT Mozilla");
	}
}