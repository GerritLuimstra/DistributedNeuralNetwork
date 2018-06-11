<?php

require "auth.php";
require "conn.php";
require "functions.php";

$extensions = ["dataset" => "csv", "neuralNetwork" => "py"];

if(!isset($_GET['type']) || !isset($_GET['project'])) die("Invalid request");
if(!in_array($_GET['type'], ["profile", "neuralNetwork", "dataset"])) die("Invalid request");
if(!isset($_FILES["theFile"])) die("Invalid request");
if(!file_exists($_FILES['theFile']['tmp_name']) || !is_uploaded_file($_FILES['theFile']['tmp_name'])) die("Please provide a file");

// Project checks
if(!owns_project($_GET['project'])) die("Unauthorized.");

if($_GET['type'] !== "profile"){

    $extension = pathinfo($_FILES['theFile']['name'], PATHINFO_EXTENSION);
    if($extension != $extensions[$_GET["type"]]) die("Please upload a file with a valid extension");

    $token = get_project_info($_GET['project'])->token;

    // Remove all old files (CSV or Python)
    $files = glob("../uploads/projects/{$token}/*." . $extensions[$_GET["type"]]);
    foreach ($files as $file) {unlink($file);}

    $name = $_FILES['theFile']['name'];
    if (move_uploaded_file($_FILES['theFile']['tmp_name'], "../uploads/projects/{$token}/{$name}")) {
        header("Location: ../project.php?id=" . intval($_GET['project']));
        exit;
    } else {
        die("ERROR: File was not uploaded. Please try again later.");
    }

}
