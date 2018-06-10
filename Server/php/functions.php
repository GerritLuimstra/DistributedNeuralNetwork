<?php

    function get_projects($userID){
        global $conn;
        $qry = "SELECT * FROM projects WHERE user_id = ?";
        $sth = $conn->prepare($qry);
        $sth->execute([$userID]);
        return $sth->fetchAll();
    }

    function sanitize($input){
        return htmlentities($input, ENT_QUOTES, 'UTF-8');
    }

    function short_print($input, $maxlength){
        if (mb_strlen($input) > $maxlength){
            return mb_substr($input, 0, $maxlength) . "...";
        } return $input;
    }

    function generate_token($project_name){
        return strtoupper(mb_substr($project_name, 0, 8)) . "-" . sha1(random_bytes(10));
    }

    function owns_project($id){
        global $conn;
        $id = (int) $id;
        $sql = "SELECT id FROM projects WHERE id = ? AND user_id = ?";
        $sth = $conn->prepare($sql);
        $sth->execute([$id, $_SESSION['userID']]);
        return $sth->rowCount() > 0;
    }

    function get_project_info($id){
        global $conn;
        $sql = "SELECT * FROM projects WHERE id = ?";
        $sth = $conn->prepare($sql);
        $sth->execute([$id]);
        return $sth->fetch();
    }

    function endsWith($haystack, $needle)
    {
        $length = strlen($needle);

        return $length === 0 ||
            (substr($haystack, -$length) === $needle);
    }

    function get_neural_network($id){
        $token = get_project_info($id)->token;
        $project_dir = "uploads/projects/$token";
        $file = glob($project_dir . "/*.py");
        if(empty($file)) return false;
        $fileInfo = (object) [];
        $fileInfo->size = filesize_formatted(filesize($file[0]));
        $fileInfo->name = basename($file[0]);
        return $fileInfo;
    }

    function get_dataset($id){
        $token = get_project_info($id)->token;
        $project_dir = "uploads/projects/$token";
        $file = glob($project_dir . "/*.csv");
        if(empty($file)) return false;
        $fileInfo = (object) [];
        $fileInfo->size = filesize_formatted(filesize($file[0]));
        $fileInfo->name = basename($file[0]);
        return $fileInfo;
    }

    function get_training_pool($id){
        $id = (int) $id;
        global $conn;
        $qry = "SELECT * FROM datapool WHERE project_id = ?";
        $sth = $conn->prepare($qry);
        $sth->execute([$id]);
        return $sth->fetchAll();
    }

function filesize_formatted($size)
{
    $units = array( 'B', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB');
    $power = $size > 0 ? floor(log($size, 1024)) : 0;
    return number_format($size / pow(1024, $power), 2, '.', ',') . ' ' . $units[$power];
}