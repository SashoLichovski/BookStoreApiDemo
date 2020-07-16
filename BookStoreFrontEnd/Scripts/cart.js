function displayCartItems(){
    var bookIds = storageService.getItems(`cartItems`);
    console.log(bookIds);
    let totalPrice = 0.00;
    bookIds.forEach(bookId => {
        axios.get(`https://localhost:44345/api/Book/${bookId}`)
            .then(function (response) {
                var data = response.data;
                var cartContainer = document.getElementById("cartContainer");

                var itemBody = document.createElement(`div`);
                itemBody.classList.add('itemBody');
                cartContainer.appendChild(itemBody);

                var bookTitle = document.createElement(`h4`);
                bookTitle.classList.add();
                bookTitle.innerText = data.title;
                itemBody.appendChild(bookTitle);

                var bookAuthor = document.createElement(`h5`);
                bookAuthor.className = "text-muted";
                bookAuthor.innerText = `by: ${data.author}`;
                itemBody.appendChild(bookAuthor);

                var bookPrice = document.createElement(`h5`);
                bookPrice.className = "text-muted";
                bookPrice.innerText = `Price:`
                itemBody.appendChild(bookPrice);

                var price = document.createElement(`h5`);
                price.innerText = data.price;
                itemBody.appendChild(price);

                var itemBtn = document.createElement(`button`);
                itemBtn.className = "btn btn-primary";
                itemBtn.innerText = "Remove from cart";
                itemBtn.onclick = function(e){
                    storageService.removeFromLocalStorage(event, data.id, "cartItems");
                    document.getElementById('totalPrice').innerText -= event.target.previousSibling.innerText;
                    itemBody.remove();
                    if (cartContainer.children.length == 0) {
                        document.getElementById('totalPrice').innerText = '';
                    }
                }
                itemBody.appendChild(itemBtn);

                totalPrice += data.price;
                document.getElementById('totalPrice').innerText = totalPrice;
            })
            .catch(function (error) {
                console.log(error);
            });
    });
}

displayCartItems();

function createOrder(){
    if(storageService.getItems("cartItems").length == 0)
    {
        alert("You can't make an order with empty cart")
    }
    else
    {
        var name = document.getElementById("name").value;
        var adress = document.getElementById("adress").value;
        var email = document.getElementById("email").value;
        var phone = document.getElementById("phone").value;
    
        var bookIds = storageService.getItems("cartItems");
    
        axios.post('https://localhost:44345/api/Order', {
            name: name,
            adress: adress,
            email: email,
            phone: phone,
            bookIds: bookIds
          })
          .then(function (response) {
            //   debugger;
            storageService.clearItems('cartItems');
            alert(`Thank you for ordering. Your tracking number is ${response.data}`);
            location.href = "./index.html";
          })
          .catch(function (error) {
            //   debugger;
            if (error.response.status == 400) {
                alert("All fields are required");
            }else if(error.response.status == 404){
                alert("One of the books in your cart went out of stock");
                location.href = "./index.html";
            }
          });
    }
    
}