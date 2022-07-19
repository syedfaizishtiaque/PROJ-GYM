function LoadMessage(message, row_sk , url) {
    $('#para_message').html(message);
    MarkasRead(row_sk, url);
    $('#noti').html("");
    GetNotifications();
   
}

function UnloadMessage() {
    $('#para_message').html('');
}

function GetNotifications() {
    $.ajax({

        url: '/Menu/GetNotifications',
        dataType: 'json',
        type: 'POST',
        contentType: 'application/json; charset=UTF-8',
        //data: Id,//{ 'fileId': Id },
        success: function (data) {
            //console.log(data);
            buildNotiDropDown(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr);
        }
    });
}


function buildNotiDropDown(msgs) {
  
    try {
        var count = 0;
        var html = '';
       
        if (msgs != null) {
            
            $.each(msgs, function (i, v) {

                if (v.msg_status == true) {
                    html += "<a href='#' class='dropdown-item' data-target='#modalMessages' data-toggle='modal' data-id='" + v.row_sk + "' onclick=\"LoadMessage(\'" + v.msg + "\' ,\'" + v.row_sk + "\' , '/Home/UpdateMessages')\">";
                    html += '<div class="media">';
                    html += '<img src="/Content/images/OpenEnvelope.png" alt="Open Envelope" class="img-size-32 mr-3 img-circle" />';
                    html += '<div class="media-body">';
                    html += '<h3 class="dropdown-item-title">';
                    html += '<span class="float-right text-sm text-blue" title="Readed Message"><i class="fas fa-check-double"></i></span>';
                    html += '</h3>';
                    html += '<p class="elipses text-sm">' + v.msg + '</p>';
                    html += '<p class="text-sm text-muted"><i class="far fa-clock mr-1"></i>' + moment(v.created_on).format('yyyy-MM-DD'); +'</p>';
                    html += '</div>';
                    html += '</div>';
                    html += '</a>';

                } else {
                    html += "<a href='#' class='dropdown-item' data-target='#modalMessages' data-toggle='modal' data-id='" + v.row_sk + "' onclick=\"LoadMessage(\'" + v.msg + "\' ,\'" + v.row_sk + "\' , '/Home/UpdateMessages')\">";
                    html += '<div class="media">';
                    html += '<img src="/Content/images/CloseEnvelope.png" alt="Close Envelope" class="img-size-32 mr-3 img-circle" />';
                    html += '<div class="media-body">';
                    html += '<h3 class="dropdown-item-title">';
                    html += '<span class="float-right text-sm text-default" title="Deliver / Not Readed"><i class="fas fa-check"></i></span>';
                    html += '</h3>';
                    html += '<p class="elipses text-sm">' + v.msg + '</p>';
                    html += '<p class="text-sm text-muted"><i class="far fa-clock mr-1"></i>' + moment(v.created_on).format('yyyy-MM-DD'); +'</p>';
                    html += '</div>';
                    html += '</div>';
                    html += '</a>';
                    count++;
                }
                html += '<div class="dropdown-divider"></div>';
            });
            $('#msgCount').html(count);
           
            $('#noti').html(html);
        }
    } catch (e) {
        console.log(e);
    }
}


function MarkasRead(row_sk, _url) {
   
    $.ajax({
        url: _url,
        type: 'POST',
        data: { row_sk: row_sk },
        success: function (res) {
            if (res != null && res != "") {
                console.log(res);
            }
        },
        error: function (request, status, errorThrown) {
            console.log(request);
        }
    });

}