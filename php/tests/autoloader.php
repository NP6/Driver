<?php

spl_autoload_register(function ($class_name) {
    $sources = ["src/$class_name.php", "Implementation/$class_name.php"];

    foreach ($sources as $source) {
        if (file_exists($source)) {
            include $source;
        }
    }
});

?>
