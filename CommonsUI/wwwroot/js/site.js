import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';

$(function () {
    ReactDOM.render(<App />, document.getElementById('root'));
    //var defaultWeek = getWeekNumber(new Date());
    //$("#week").val(defaultWeek);
    //weekChanged(defaultWeek);
    //$("#week").change(function () {
    //    $(this).attr("disabled", true);
    //    weekChanged($(this).val());
    //});
})

function weekChanged(input) {
    var newWeek = input.split("-W");
    var monday = getDateOfISOWeek(newWeek[1], newWeek[0]);
    // 5 = friday
    var sunday = getNextDayOfWeek(monday, 7);
    loadEvents(monday, sunday);
}

function loadEvents(from, to) {
    var url = "https://localhost:5001/api/events/"+from+"/"+to;
    $.ajax({
        url: url,
        crossDomain: true,
        type: 'get',
        success:function(data,code){    
            data = JSON.parse(data);
            showEvents(data);
            $('.event_header').click(function(){
                $(this).siblings('.f_info').toggle();
            });
            $('.member').click(function(){
                var id = $(this).attr('mid');
                $('#alert_text').text("would have called api to return member object for id "+id);
                $('#alert').show();
            })
            $("#week").attr("disabled", false);
        }
    });
   
}

function showEvents(events){
    const calendar = $('#calendar');
    calendar.empty();
    $.each(events['eventList'], function(i, item) {
        calendar.append(createEventDiv(item));
    });
}

function createEventDiv(event){
    var div = "<Event name='"+eventTitle(event['startDate'], event['startTime'], event['endDate'], event['endTime'] ,event['description'])+"' />";
    //div += furtherInfoDiv(event['memberList']['memberList'], event['category']);
    //div += "</div>";
    return div;
}

function eventTitle(startDate, startTime, endDate, endTime, desc){
    startDate = startDate.replace("T00:00:00","");
    endDate = endDate.replace("T00:00:00","");
    //should be done serverside
    if(!startTime){
        startTime = "TBC";
    }if(!endTime){
        endTime = "TBC";
    }
    return startDate+" "+startTime+" - "+endDate+" "+endTime+" - "+desc;
}

function furtherInfoDiv(members, category){
    var div = "<div style='display: none' class='f_info'>"
    div += "<p>Category : "+category+"</p>"
    if(members.length > 0){
        div += "<ul>";
        $.each(members, function(i, member) {
            div += "<li class='member' mid='"+member['id']+"'>"+member['displayName']+"</li>";
        });
        div += "</ul>";
    }
    div += "</div>";
    return div;
}

class Event extends React.Component {
  render() {
    return (
      <div className="event">
        <h5 className="event_header">{this.props.name}</h5>
      </div>
    );
  }
}