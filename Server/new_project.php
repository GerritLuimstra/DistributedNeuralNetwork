<?php
    require "php/auth.php";
    require "php/conn.php";
    require "php/functions.php";

    if(isset($_POST['add-btn'])){
        $name = sanitize(preg_replace("/[^A-Za-z0-9 ]/", '', mb_substr($_POST['name'], 0, 100)));
        $desc = sanitize(mb_substr($_POST['description'], 0, 500));

        $token = generate_token($name);

        $sql = "INSERT INTO projects VALUES (DEFAULT, :token, :name, :desc, DEFAULT, :userID)";
        $sth = $conn->prepare($sql);
        $sth->execute([
            ":token" => $token,
            ":name" => $name,
            ":desc" => $desc,
            ":userID" => $_SESSION['userID']
        ]);

        mkdir("uploads/projects/" . $token);
        mkdir("uploads/projects/" . $token . "/splits");
        mkdir("uploads/projects/" . $token . "/results");

        header("Location: index.php");
        exit;
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
    <nav>
        <div class="nav-wrapper blue lighten-1">
            <a href="index.php" class="brand-logo">Project DNN</a>
            <ul id="nav-mobile" class="right">
                <li><a href="index.php">Dashboard</a></li>
            </ul>
        </div>
    </nav>


    <div class="container">

        <h4>Create a new project</h4>

        <div class="row">
            <form class="col s12" method="POST" action="new_project.php">
                <div class="row">
                    <div class="input-field col s12">
                        <input id="email" type="text" name="name" maxlength="100">
                        <label for="email">Please name your project</label>
                    </div>
                </div>
                <div class="row">
                    <div class="input-field col s12">
                        <textarea id="desc" class="materialize-textarea" maxlength="500" name="description"></textarea>
                        <label for="desc">Please enter your projects description</label>
                    </div>
                </div>
                <button class="btn waves-effect waves-light" type="submit" name="add-btn">Create
                    <i class="material-icons right">add</i>
                </button>
            </form>
        </div>




    </div>

    <script type="text/javascript" src="js/materialize.min.js"></script>
    </body>
</html>
