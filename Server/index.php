<?php
include("conn.php");

$db = new dbObj();
$connection = $db->getConnection();
$request_method = $_SERVER["REQUEST_METHOD"];


switch($request_method){
    case 'GET':
        if(!empty($_GET["id"])){
            $id = intval($_GET["id"]);
            get_blueray_by_id($id);
        }else
            get_all_blueray();
        break;

    case 'POST':
        insert_blueray();
        break;

    case 'PUT':
        $id = intval($_GET["id"]);
        update_blueray($id);
        break;

    case 'DELETE':
        $id = intval($_GET["id"]);
        delete_blueray($id);
        break;

    default:
        header("HTTP/1.0 405 Method Not Allowed");
        break;
}



function get_all_blueray(){
    global $connection;
    $query = "SELECT * FROM blueray";
    $response = array();
    $result = mysqli_query($connection, $query);
    while($row=mysqli_fetch_array($result))
        $response[] = $row;

    header('Content-Type: application/json');
    echo json_encode($response);
}


function get_blueray_by_id($id=0){
    global $connection;
    $query = "SELECT * FROM blueray";
    if($id != 0) $query.= " WHERE id =".$id." LIMIT 1"; //
    $response = array();
    $result = mysqli_query($connection, $query);
    while($row=mysqli_fetch_array($result))
        $response[] = $row;

    header('Content-Type: application/json');
    echo json_encode($response);
}


function delete_blueray($id){
    global $connection;
    $query= "DELETE FROM blueray WHERE id = ".$id;

    if(mysqli_query($connection, $query)){
        $response = array(
            'status' => 1,
            'status_message' => 'Blueray törölve'
        );
    }else{
        $response = array(
            'status' => 0,
            'status_message' => 'Bluray törlése meghiúsult'
        );
    }

    header('Content-Type: application/json');
    echo json_encode($response);
}
function insert_blueray(){
    global $connection;

    $data = json_decode(file_get_contents('php://input'),true);
    $title = $data["title"];
    $director = $data["director"];
    $actor = $data["actor"];
    $genre = $data["genre"];
    $playtime = $data["playtime"];
    $price = $data["price"];

    $query = "INSERT INTO blueray SET title =' ". $title." ' ,director=' ".$director." ',
      actor =' ".$actor." ', genre =' ".$genre." ',  playtime =' ".$playtime." ',  price =' ".$price." '";

    if(mysqli_query($connection, $query)){
        $response = array(
            'status' => 1,
            'status_message' => 'Blueray inserted successfully'
        );
    }else{
        $response = array(
            'status' => 0,
            'status_message' => 'Blueray insertion failed'
        );
    }

    header('Content-Type: application/json');
    echo json_encode($response);
}

function update_blueray($id){
    global $connection;
    $data = json_decode(file_get_contents("php://input"), true);
    $title = $data["title"];
    $director = $data["director"];
    $actor = $data["actor"];
    $genre = $data["genre"];
    $playtime = $data["playtime"];
    $price = $data["price"];
    $id = $data["id"];


    $query = "UPDATE blueray SET title =' ".$title." ',director =' ".$director." ',
      actor =' ".$actor." ', genre =' ".$genre." ',  playtime =' ".$playtime." ',  price =' ".$price." ' WHERE id = ".$id;


    $myfile = file_put_contents('logs.txt', $query.PHP_EOL , FILE_APPEND | LOCK_EX);

    if(mysqli_query($connection, $query)){
        $response = array(
            "status" => 1,
            "message" => "Update successfully"
        );
    }else{
        $response = array(
            "status" => 0,
            "message" => "Update failed"
        );
    }
    header("Content-Type: application/json");
    echo json_encode($response);
}
