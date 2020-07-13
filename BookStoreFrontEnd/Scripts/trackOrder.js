function getOrder(){
    var email = document.getElementById(`orderEmail`).value;
    var trackingNo = document.getElementById(`trackingNumber`).value;

    axios.get(`https://localhost:44345/api/Order/track?email=${email}&trackingNumber=${trackingNo}`)
        .then(function (response) {
        console.log(response);
        })
        .catch(function (error) {
        alert("Both email and tracking number fields are required");
        });
}