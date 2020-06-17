window.componentInterop = {
    deleteChild: (id, index) => {
        var parent = document.getElementById(id);
        var child = parent?.children[index];
        if (parent && child)
            parent.removeChild(child);
    }
}

window.interopThreading = {
    setCallbackInterval: (instance, delay) => {
        console.log(delay);
        setInterval(() => instance.invokeMethodAsync('UpdateDateTime1'), delay);
    },

    setTimerInterval: (elementId, delay) => {
        const element = document.getElementById(elementId);
        setInterval(() => {
            var date = new Date();
            element.innerText = date.toLocaleTimeString() + "." + ("00" + date.getMilliseconds()).slice(-3)
        }, delay);
    }
}