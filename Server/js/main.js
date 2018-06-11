$(document).ready(function(){

    $("#uploadNN").on('click', function(){
       displayModal(
           "Upload Neural Network",
           "Please upload your Neural Network (Python) script",
           "neuralNetwork"
       );
    });

    $("#uploadDataset").on('click', function(){
        displayModal(
            "Upload Dataset",
            "Please upload your data set in CSV format",
            "dataset"
        );
    });



    $(".popup .content .close").on("click", function(){
        $(".popup").fadeOut();
        $(".overlay").fadeOut();
    });

});

function displayModal(title, content, type){
    $(".popup .title h6").text(title);
    $(".popup .content p").text(content);
    $(".popup .content form").attr("action", "php/upload.php?type=" + type + "&project=" + $("#projectID").val());
    $(".popup").fadeToggle();
    $(".overlay").fadeToggle();
}