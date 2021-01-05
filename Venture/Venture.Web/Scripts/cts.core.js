/// <reference path="/scripts/jquery-1.10.1-vsdoc.js" />

/********************************************************************************
Summary: Core jQuery library to support web application development.
Author: CTS Inc
Date: July 29, 2013
Copyright : Copyright (c) 2013 Computer Technology Solutions, Inc.  ALL RIGHTS RESERVED
ProductName: cts.core.js
Version: 1.0.0
*********************************************************************************/

function displayError(data) {
    var summary = $('#PageError');
    var ul = $('#PageError > ul');
    ul.remove('li');

    summary.addClass('alert alert-error validation-summary-errors').removeClass("validation-summary-valid");

    ul.html(data.responseText);
}

function cleanError() {
    var summary = $('#PageError');
    var ul = $('#PageError > ul');
    ul.remove('li');

    summary.removeClass('alert alert-error validation-summary-errors').addClass("validation-summary-valid");

    ul.add("<li style='display:none;' />");
}

/* Dialog */
function showDialog(id) {
   $('#' + id).modal('show');
}

function closeDialog(id) {
   $('#' + id).modal('hide');
}