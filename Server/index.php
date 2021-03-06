<?php
require "php/auth.php";
require "php/conn.php";
require "php/functions.php";

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
        <nav>
            <div class="nav-wrapper blue lighten-1">
                <a href="index.php" class="brand-logo">Project DNN</a>
                <ul id="nav-mobile" class="right">
                    <li><a href="sass.html">Logout</a></li>
                </ul>
            </div>
        </nav>


        <div class="container">
            <h6>Welcome back <?= sanitize($_SESSION['name']) ?></h6>
            <h4>Projects</h4>
            <a class="waves-effect waves-light btn blue lighten-1" href="new_project.php"><i class="material-icons left">add</i>Add</a>
            <ul class="collection">
                <?php foreach(get_projects($_SESSION['userID']) as $project){ ?>
                <li class="collection-item avatar">
                    <img src="uploads/<?= sanitize($project->picture) ?>" alt="<?= sanitize($project->name) ?>" class="circle">
                    <a href="project.php?id=<?= $project->id ?>"><span class="title"><?= sanitize($project->name) ?></span></a>
                    <p><i><?= short_print(sanitize($project->desc), 100) ?></i></p>
                    <a href="#!" class="secondary-content"><i class="material-icons">folder</i></a>
                    <form method='post' action='#'>
                        <input type='button' name='button_delete'>
                    </form>
                    <?php
                    if(isset($_POST['button_delete'])){
                    $sql = "DELETE FROM projects WHERE id={$project->id}";
                    $conn->query($sql);
                    }
                    ?>
                    </li>
                    <?php }
                    ?>
            </ul>
        </div>

        <script type="text/javascript" src="js/materialize.min.js"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    </body>
</html>
