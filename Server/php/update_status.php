<?php

$done = ["main"=>false, "client1"=>false, "client2"=>false, "client3"=>false];
if(file_exists("results/main.txt")){
    $done["main"] = true;
}
if(file_exists("results/client1.txt")){
    $done["client1"] = true;
}
if(file_exists("results/client2.txt")){
    $done["client2"] = true;
}
if(file_exists("results/client3.txt")){
    $done["client3"] = true;
}

echo json_encode($done);