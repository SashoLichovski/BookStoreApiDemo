storageService = {
    existsInLocalStorage : function(item, storageKey){
        var exists = false;
        if (JSON.parse(localStorage.getItem(storageKey)) != null && JSON.parse(localStorage.getItem(storageKey)).includes(item)) {
            exists = true;
        }
        return exists;
    },
    addToLocalStorage: function(event, item, storageKey){
        var cartItems = JSON.parse(localStorage.getItem(storageKey))
        if (cartItems == null) {
            cartItems = [];
        }
        if (!cartItems.includes(item)) {
            cartItems.push(item);
        }
        localStorage.setItem(storageKey, JSON.stringify(cartItems));
        event.target.innerText = `Remove from cart`;
    },
    removeFromLocalStorage: function(event, item, storageKey){
        var cartItems = JSON.parse(localStorage.getItem(storageKey));
        var filtered = cartItems.filter(x => {
            return x != item;
        })
        localStorage.setItem(storageKey, JSON.stringify(filtered));
        event.target.innerText = `Add to cart`;
    },
    getItems: function(storageKey){
        var arr = [];
        if (JSON.parse(localStorage.getItem(storageKey)) != null) {
            arr = JSON.parse(localStorage.getItem(storageKey));
        }
        return arr;
    },
    clearItems: function(storageKey){
        var arr = storageService.getItems('cartItems');
        arr = [];
        localStorage.setItem(storageKey, JSON.stringify(arr));
    }
}