<?php

try {
    //$conn = new PDO("mysql:dbname=projectdnn;host=localhost", "projectdnn", "N_rjpG1833");
    $conn = new PDO("mysql:dbname=projectdnn;host=localhost", "root", "");
    $conn->setAttribute(PDO::ATTR_DEFAULT_FETCH_MODE, PDO::FETCH_OBJ);
} catch(PDOException $e){
    die("Database connection could not be established. Please try again later.");
}
