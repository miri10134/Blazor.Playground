window.componentInterop = {
    deleteChild: (id, index) => {
        var parent = document.getElementById(id);
        var child = parent?.children[index];
        if (parent && child)
            parent.removeChild(child);
    }
}

window.jsInterop = {
    returnDoubled: (number) => {
        const result = number * 2;
        console.log("js: number = " + number + ", result = " + result);
        return result;
    },
    callBack: (instance, methodName, parameterValue) => {
        console.log("js: invoke callback Async");
        instance.invokeMethodAsync(methodName + "Async", parameterValue)
            .then(() => console.log("js: " + methodName + "Async done"));
        console.log("js: invoke callback");
        instance.invokeMethod(methodName, parameterValue);
        console.log("js: callbacks done");
    },
    callStaticMethod: (numberOfElements) => {
        console.log("js: numberOfElements = " + numberOfElements);
        DotNet.invokeMethodAsync('Blazor.Playground.UI.Components', 'GenerateRandomNumbers', numberOfElements)
            .then(data => console.log("js: " + data));
    }
}

window.threadingInterop = {
    setCallbackInterval: (instance, delay) => {
        setInterval(() => instance.invokeMethodAsync('UpdateDateTime1'), delay);
    },

    setTimerInterval: (element, delay) => {
        setInterval(() => {
            var date = new Date();
            element.innerText = date.toLocaleTimeString() + "." + ("00" + date.getMilliseconds()).slice(-3)
        }, delay);
    }
}

window.addListener = (element, event) => {
    element.addEventListener(event, window.logMouseClick);
}

window.logMouseClick = (event) => {
    console.log("MouseClick: " + event.offsetX + " : " + event.offsetY);
}