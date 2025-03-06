// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

import { image } from "d3";

// Write your JavaScript code.






function changeImage(e) {

    image.src = window.URL.createObjectURL(e.files[0])

}