<!-- render button for send -->
<div class="label one columns input-group">
  <?php
        echo
            $this->Html->link(
                                __('Buscar ...', true),
                                array('action' => 'get', null),
                                array('id'=>'send_query','div'=>false,'class'=>'btn btn-primary btn-sm pull-right','tabindex'=>'6')
                              );
  ?>
</div>

<!-- update div -->
  <div id="updateSearchResult" class="updateSearchResult"></div>

<script type="text/javascript">

// click button(div::send_query) and call to get.ctp view then render in index.ctp::div:.updateSearchResult beforecomplete the call render a spinner

$("#send_query").on('click', function(event) { // wait for click

  event.stopPropagation();
  event.preventDefault();

// catch the id of the div and get the data like id's for send the query to method Controller::get()
  var data_code = $(this).attr('id');
  var serial = JSON.stringify($("#pform").serializeArray());
  data_code = base64_encode(serial);
  // build the url
  var urlStruct = "<?php echo Dispatcher::baseUrl();?>/PerformanceReferences/get/data:"+data_code;
  // render spinner
  $(".updateSearchResult").html('<div class="text-center"><i class="fa fa-spinner fa-pulse fa-2x fa-fw"></i><span class="sr-only">Loading...</span><div>');
  // call get.ctp and send post data then print get.ctp view in div
  $( ".updateSearchResult" ).load(urlStruct,function(responseText, statusText, xhr) {
    # Some Code
  });

}); // end on_click

</script>
