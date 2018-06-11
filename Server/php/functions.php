<?php

    error_reporting(E_ALL);
    ini_set('display_errors', true);

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
        return strtoupper(mb_substr($project_name, 0, 8)) . "-" . sha1(substr(md5(rand()), 0, 7));
    }

    function owns_project($id){
        global $conn;
        $id = (int) $id;
        $sql = "SELECT id FROM projects WHERE id = ? AND user_id = ?";
        $sth = $conn->prepare($sql);
        $sth->execute([$id, $_SESSION['userID']]);
        return $sth->rowCount() > 0;
    }

    function get_id_by_token($token){
        global $conn;
        $sql = "SELECT id FROM projects WHERE token = ?";
        $sth = $conn->prepare($sql);
        $sth->execute([$token]);
        return $sth->fetch()->id;
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

    function get_available_splits($project_id){
        global $conn;
        $qry = "SELECT * FROM datapool WHERE project_id = ? AND status = 0";
        $sth = $conn->prepare($qry);
        $sth->execute([$project_id]);
        return $sth->fetchAll();
    }

    function get_results($token){
        if(!is_dir("uploads/projects/{$token}/results")) return false;
        $result = [];
        foreach(scandir("uploads/projects/{$token}/results/") as $item){
            if(!is_dir("uploads/projects/{$token}/results/" . $item)) continue;
            if($item == "." || $item == "..") continue;
            $result[$item] = [];
            foreach(scandir("uploads/projects/{$token}/results/{$item}/") as $file){
                if($file == "." || $file == "..") continue;
                $result[$item][] = $file;
            }
        }
        return $result;
    }

    function split_exists($splitName, $projectID){
        global $conn;
        $splitName = sanitize($splitName);
        $qry = "SELECT id FROM datapool WHERE project_id = ? AND name = ?";
        $sth = $conn->prepare($qry);
        $sth->execute([$projectID, $splitName]);
        return $sth->rowCount() > 0;
    }

    function project_exists($token){
        global $conn;
        $qry = "SELECT id FROM projects WHERE token = ?";
        $sth = $conn->prepare($qry);
        $sth->execute([$token]);
        return $sth->rowCount() > 0;
    }

    function force_download($file_url){
        header('Content-Type: application/octet-stream');
        header("Content-Transfer-Encoding: Binary");
        header("Content-disposition: attachment; filename=\"" . basename($file_url) . "\"");
        readfile($file_url); // do the double-download-dance (dirty but worky)
    }

    function update_split_status($projectID, $datasetName, $status){
        global $conn;
        $qry = "UPDATE datapool SET status = ? WHERE project_id = ? AND name = ?";
        $sth = $conn->prepare($qry);
        $sth->execute([$status, $projectID, $datasetName]);
    }

    function filesize_formatted($size){
        $units = array( 'B', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB');
        $power = $size > 0 ? floor(log($size, 1024)) : 0;
        return number_format($size / pow(1024, $power), 2, '.', ',') . ' ' . $units[$power];
    }

    function can_merge($projectID){
        global $conn;
        $qry = "SELECT id FROM datapool WHERE project_id = ?";
        $sth = $conn->prepare($qry);
        $sth->execute([$projectID]);

        $qry2 = "SELECT id FROM datapool WHERE project_id = ? AND status = 2";
        $sth2 = $conn->prepare($qry2);
        $sth2->execute([$projectID]);

        return $sth->rowCount() > 0 && $sth->rowCount() == $sth2->rowCount();
    }