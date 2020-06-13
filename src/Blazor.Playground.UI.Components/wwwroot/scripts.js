window.componentInterop = {
    deleteChild: (id, index) => {
        var parent = document.getElementById(id);
        var child = parent?.children[index];
        if (parent && child)
            parent.removeChild(child);
    }
}