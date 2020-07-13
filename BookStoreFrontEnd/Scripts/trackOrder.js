function getOrder(){
    var email = document.getElementById(`orderEmail`).value;
    var trackingNo = document.getElementById(`trackingNumber`).value;

    axios.get(`https://localhost:44345/api/Order/track?email=${email}&trackingNumber=${trackingNo}`)
        .then(function (response) {
        console.log(response.data);
        var data = response.data;
        document.getElementById("searchOrderContainer").style.display = 'none'; 
        // debugger;
        var container = document.getElementById(`orderDetailsContainer`);

        var name = document.createElement(`p`);
        name.classList.add();
        name.innerText = `Name: ${data.name}`;
        container.appendChild(name);

        var adress = document.createElement(`p`);
        adress.classList.add();
        adress.innerText = `Adress: ${data.adress}`;
        container.appendChild(adress);

        var email = document.createElement(`p`);
        email.classList.add();
        email.innerText = `Email: ${data.email}`;
        container.appendChild(email);

        var phone = document.createElement(`p`);
        phone.classList.add();
        phone.innerText = `Phone: ${data.phone}`;
        container.appendChild(phone);

        var trackingNo = document.createElement(`p`);
        trackingNo.classList.add();
        trackingNo.innerText = `Tracking number: ${data.trackingNumber}`;
        container.appendChild(trackingNo);

        var price = document.createElement(`p`);
        price.classList.add();
        price.innerText = `Price: ${data.fullPrice}`;
        container.appendChild(price);

        var books = document.createElement(`p`);
        books.innerText = 'Books:';
        container.appendChild(books);

        var bookList = document.createElement(`ul`);
        container.appendChild(bookList);

        data.bookTitles.forEach(title => {
            var newTitle = document.createElement(`li`);
            newTitle.innerText = title;
            bookList.appendChild(newTitle);
        });

        })
        .catch(function (error) {
            if (error.response.status == 404) {
                alert("Order not found. Please check your details");
            }else if(error.response.status == 400){
                alert("Both email and tracking number fields are required");
            }
        });
}