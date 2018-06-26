<?php

require "auth.php";
require "conn.php";
require "functions.php";

if(!isset($_GET['project_id'])) die("Invalid request. No project ID specified.");
if(!owns_project($_GET['project_id'])) die("You do not own this project");

$projectID = $_GET['project_id'];

// Find the results for the project
$project = get_project_info($projectID);
$token = $project->token;

$project_path = "../uploads/projects/{$token}/";
$path_to_master = $project_path . "master/";
$s_who = $path_to_master . "who.npy";
$s_wih = $path_to_master . "wih.npy";

// TODO: Skip if not found.. Means it already IS the server... ;-)
foreach(scandir($project_path . "results") as $dir){
    if($dir == "." || $dir == "..") continue;
    $who = $project_path . "results/" . $dir . '/who.npy';
    $wih = $project_path . "results/" . $dir . '/wih.npy';
    if(!file_exists($who)) continue;

    // Move them to the folder to merge
    copy($who, "../mergeArea/client_who.npy");
    copy($wih, "../mergeArea/client_wih.npy");
    copy($s_who, "../mergeArea/server_who.npy");
    copy($s_wih, "../mergeArea/server_wih.npy");

    chdir("../mergeArea/");
    $command = "cmd /c merger.bat";
    system($command);
    sleep(2);
    chdir("../php/");

    rename("../mergeArea/merged_who.npy", $path_to_master . "who.npy");
    rename("../mergeArea/merged_wih.npy", $path_to_master . "wih.npy");

}

header("Location: ../project.php?id=" . $_GET['project_id']);
exit;










//system('cmd /c start ..\mergeArea\merger.bat');
