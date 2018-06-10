<?php

session_start();

$_SESSION['loggedIn'] = true;
$_SESSION['userID'] = 1;
$_SESSION['name'] = "Gerrit Luimstra";