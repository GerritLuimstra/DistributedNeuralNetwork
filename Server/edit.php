<?php
require "php/auth.php";
require "php/conn.php";
require "php/functions.php";

if (!isset($_GET['id']))
    die("Invalid project id.");
if (!owns_project($_GET['id']))
    die("You do not have permission to access this project.");

$project = get_project_info($_GET['id']);

if (isset($_POST['submit'])) {
    $name = sanitize(preg_replace("/[^A-Za-z0-9 ]/", '', mb_substr($_POST['name'], 0, 100)));
    $desc = sanitize(mb_substr($_POST['description'], 0, 500));
    $id = $project->id;
    
    $target_dir = "uploads/projects/";
    $target_file = $target_dir . basename($_FILES["uploadFile"]["name"]);
    move_uploaded_file($_FILES["uploadFile"]["tmp_name"], $target_file);
    $picture = "/Server/img/" . basename($_FILES["uploadFile"]["name"]);
    
    $sql = "UPDATE `projects` SET `token`='{$token}', `name`='{$name}', `desc`='{$desc}', `picture`='{$picture}' WHERE `projects`.`id`={$id}";
    $conn->query($sql);
    
//    header("Location: index.php");
//    exit;
}
?>
<!DOCTYPE html>
<html>
    <head>
        <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
        <link type="text/css" rel="stylesheet" href="css/materialize.min.css"  media="screen,projection"/>
        <link rel="stylesheet" href="css/custom.css">
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    </head>

    <body>
        <input type="hidden" id="projectID" value="<?= $project->id ?>">

        <nav>
            <div class="nav-wrapper blue lighten-1">
                <a href="index.php" class="brand-logo">Project DNN</a>
                <ul id="nav-mobile" class="right">
                    <li><a href="sass.html">Logout</a></li>
                </ul>
            </div>
        </nav>
        <div class="container">
            <div class="row">
                <div class="col s2">
                    <img src="uploads/<?= sanitize($project->picture) ?>" alt="<?= sanitize($project->name) ?>" class="circle responsive-img" style="width: 100px; height: 100px;">
                </div>
                <div class="col s10">
                    <h2>Project <span style="color: #4caf50"><?= sanitize($project->name) ?></span></h2>
                    <h5>Token: <span style="color: #4caf50"><?= $project->token ?></span></h5>
                </div>

                <h6>"<?= sanitize($project->desc) ?>"</h6>

                <form action="edit.php?id=<?= sanitize($project->id) ?>" method="POST" enctype="multipart/form-data">
                    <input type="file" name="uploadFile">
                    <input type="text" name="name">
                    <input type="text" name="description">
                    <input type="submit" name="submit">
                </form>
            </div>
        </div>

    </body>
</html>
