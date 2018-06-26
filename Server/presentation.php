<?php
    require "php/auth.php";
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
            </div>
        </nav>


        <div class="container">


            <br>
                <a class="waves-effect waves-light btn" id="startClients"><i class="material-icons left">play_arrow</i>Start clients</a>
            <br>

            <h2>Presentation</h2>

            <div class="row">
                <div class="col s12 m3">
                    <div class="card">
                        <div class="card-image">
                            <img src="img/computer.png" style="width: 300px !important;">
                            <span class="card-title">Main Computer</span>
                        </div>
                        <div class="card-content">
                            <p>This is the main computer. It is training on the full data set. It has been doing this since the beginning of this presentation.</p>
                        </div>
                        <div class="card-action">
                            <div id="secondTenthsExampleMain">
                                Time elapsed: <div class="values"></div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col s12 m3">
                    <div class="card">
                        <div class="card-image">
                            <img src="img/mnist.png">
                            <span class="card-title">Card Title</span>
                        </div>
                        <div class="card-content">
                            <p>This is a client computer. It has just been started</p>
                        </div>
                        <div class="card-action">
                            <div id="secondTenthsExampleClient1">
                                Time elapsed: <div class="values">Not started yet.</div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col s12 m3">
                    <div class="card">
                        <div class="card-image">
                            <img src="img/mnist.png">
                            <span class="card-title">Card Title</span>
                        </div>
                        <div class="card-content">
                            <p>This is a client computer. It has just been started</p>
                        </div>
                        <div class="card-action">
                            <div id="secondTenthsExampleClient2">
                                Time elapsed: <div class="values">Not started yet.</div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col s12 m3">
                    <div class="card">
                        <div class="card-image">
                            <img src="img/mnist.png">
                            <span class="card-title">Card Title</span>
                        </div>
                        <div class="card-content">
                            <p>This is a client computer. It has just been started</p>
                        </div>
                        <div class="card-action">
                            <div id="secondTenthsExampleClient3">
                                Time elapsed: <div class="values">Not started yet.</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script type="text/javascript" src="js/materialize.min.js"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
        <script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>
        <script src="js/timer.js"></script>
        <script src="js/presentation.js"></script>
    </body>
</html>
