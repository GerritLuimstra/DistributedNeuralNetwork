<?php

if(!isset($_GET['project'])) {
    die("Please specify a project");
}

echo "You are viewing project " . $_GET['project'];



