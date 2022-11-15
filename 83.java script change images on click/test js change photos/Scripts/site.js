function changeImage() {
    imageIndex++;

    if(imageIndex >= imagesArray.length){
        imageIndex = 0;
    }
    image.setAttribute("src", imagesArray[imageIndex]);
}

var imagesArray = ["Images/GreenBubbles.jpg", "Images/Peacock.jpg",
                        "Images/ShadesOfBlue.jpg", "Images/Tulip.jpg"];
var image = document.getElementById("mainImage");
var imageIndex = 0;

//setInterval(changeImage, 2000);
var text = document.getElementById("simpleText");
text.innerHTML = "Hello, World";