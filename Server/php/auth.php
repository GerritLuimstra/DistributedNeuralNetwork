<?php
    session_start();

    function logged_in(){
        return isset($_SESSION['loggedIn']) && $_SESSION['loggedIn'] == true;
    }

    if(!logged_in()){
        header("Location: unauth.php");
        exit;
    }
