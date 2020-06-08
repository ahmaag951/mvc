window._originalAlert = window.alert;
window.alert = function(text) {
    var bootStrapAlert = function() {
        if(! $.fn.modal.Constructor)
            return false;
        if($('#windowAlertModal').length == 1)
            return true;
        $('body').append(' \
    <div id="windowAlertModal" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true"> \
  <div class="modal-dialog">\
                <div class="modal-content">\
      <div class="modal-body"> \
      <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button> \
        <p> alert text </p> \
      </div> \
      <div class="modal-footer"> \
        <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">إغلاق</button> \
      </div> \
    </div> \
      </div> \
    </div> \
    ');
        return true;
    }
    if ( bootStrapAlert() ){
        $('#windowAlertModal .modal-body p').text(text);
        $('#windowAlertModal').modal();
    }  else {
        console.log('bootstrap was not found');
        window._originalAlert(text);
    }
}