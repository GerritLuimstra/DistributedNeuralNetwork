<?php

require "php/conn.php";
require "php/functions.php";

// Whenever a user requests a project by a given token, we create a zip file for the neural network and dataset
if(isset($_GET['token']) && !isset($_FILES['file'])){
    $token = $_GET['token'];
    if(!project_exists($token)) die("Invalid request. This token does not exist");
    $projectID = get_id_by_token($token);
    $project = get_project_info($projectID);
    $pool = get_available_splits($projectID);

    // Grab the first dataset. If there is none, there are no more files to distribute
    if(isset($pool[0])){
        $distribute = $pool[0];
        $datasetName = $pool[0]->name;
        $datasetLoc = "uploads/projects/{$token}/splits/{$datasetName}";
        $neuralNetwork = get_neural_network($projectID);
        if(!$neuralNetwork) die("The neural network for this project does not exist.");
        $neuralNetworkLoc = "uploads/projects/{$token}/" . $neuralNetwork->name;

        if(file_exists($datasetLoc)){
            $zipArchive = new ZipArchive();
            if ($zipArchive->open("tmp/{$datasetName}.zip", ZipArchive::CREATE) === TRUE)
            {
                // Add files to the zip file
                $zipArchive->addFile($datasetLoc, $datasetName);
                $zipArchive->addFile($neuralNetworkLoc, $neuralNetwork->name);

                // All files are added, so close the zip file.
                $zipArchive->close();

                update_split_status($projectID, $datasetName, "1");

                force_download("tmp/{$datasetName}.zip");

                // Remove all contents
                array_map('unlink', glob("tmp/*"));
                exit;
            } else {
                die("Could not provide download. Internal error");
            }
        } else {
            die("There was a problem distributing the dataset. It does not exist on disk.");
            // TODO: Remove row from DB!?
        }

    } else {
        die("No more datasets to distribute");
    }
}
// A client applet is trying to upload something
else if(isset($_FILES['file'])){

    if(!isset($_GET['token'])) die("Invalid request. Token is missing");
    if(!file_exists($_FILES['file']['tmp_name']) || !is_uploaded_file($_FILES['file']['tmp_name'])) die("Please provide a file");
    $token = $_GET['token'];
    $result = $_FILES['file'];
    $splitName = pathinfo($result["name"], PATHINFO_FILENAME);
    $extension = pathinfo($result["name"], PATHINFO_EXTENSION);
    if($extension != "zip") die("Invalid file. Needs to be a ZIP file");
    if(!project_exists($token)) die("This token is invalid");
    $projectID = get_id_by_token($token);
    if(!split_exists($splitName, $projectID)) die("This split does not exist.");
    $zipLoc = "uploads/projects/{$token}/results/{$result['name']}";

    move_uploaded_file($result['tmp_name'], $zipLoc);

    $zip = new ZipArchive;
    $splitNameNoExt = pathinfo($splitName, PATHINFO_FILENAME);
    if ($zip->open($zipLoc) === TRUE) {
        $zip->extractTo("uploads/projects/{$token}/results/{$splitNameNoExt}");
        $zip->close();

        update_split_status($projectID, $splitName, "2");
        unlink($zipLoc);

        exit;
    } else {
        die("Something went wrong extracting the ZIP archive. Try again later.");
    }

}


else if(isset($_GET['check'])){

    if(project_exists($_GET['check'])){
        echo "true";
    } else {
        echo "false";
    }

}