function displayBooks(){
    axios.get('https://localhost:44345/api/Book')
    .then(function (response) {
      console.log(response.data);
      var data = response.data;

    //Create book
    data.forEach(book => {
        generateBook(book);
    });
        
    })
    .catch(function (error) {
      console.log(error);
    });
}

function generateBook(book){
    var container = document.getElementById("bookContainer");

    var card = document.createElement("div");
    card.classList.add("card");
    container.appendChild(card);

    var cardBody = document.createElement(`div`);
    cardBody.classList.add(`card-body`);
    card.appendChild(cardBody);

    var cardTitle = document.createElement(`h5`);
    cardTitle.classList.add(`card-title`);
    cardTitle.innerText = book.title
    cardBody.appendChild(cardTitle);

    var cardAuthor = document.createElement(`h6`);
    cardAuthor.className = "card-subtitle mb-2 text-muted";
    cardAuthor.innerText = `by: ${book.author}`;
    cardBody.appendChild(cardAuthor);

    var cardDescription = document.createElement(`p`);
    cardDescription.classList.add(`card-text`);
    cardDescription.innerText = book.description;
    cardBody.appendChild(cardDescription);

    var cardGenre = document.createElement(`p`);
    cardGenre.className = "card-subtitle mb-2 text-muted";
    cardGenre.innerText = `Genre: ${book.genre}`;
    cardBody.appendChild(cardGenre);

    var inStock = document.createElement(`p`);
    inStock.className = "card-subtitle mb-2 text-muted";
    book.quantity != 0 ? 
    inStock.innerText = `In stock: ${book.quantity}` :
    inStock.innerText = `out of stock`;
    cardBody.appendChild(inStock);

    var cardBtn = document.createElement(`button`);
    cardBtn.className = "btn btn-primary";

    if (storageService.existsInLocalStorage(book.id, 'cartItems')) {
        cardBtn.innerText = "Remove from cart";
        cardBtn.onclick = function(e){
            removeFromCart(event, book.id);
        }
    }else{
        cardBtn.innerText = "Add to cart";
        cardBtn.onclick = function(e){
            addToCart(event, book.id)
        }
    }

    cardBody.appendChild(cardBtn);
}

function addToCart(event, bookId){
    storageService.addToLocalStorage(event, bookId, 'cartItems')
    event.target.innerText = "Remove from cart";
    event.target.onclick = function(e) {
        removeFromCart(event, bookId);
    }
}

function removeFromCart(event, bookId){
    storageService.removeFromLocalStorage(event, bookId, 'cartItems')
    event.target.innerText = "Add to cart";
    event.target.onclick = function(e) {
        addToCart(event, bookId);
    }
}

displayBooks();