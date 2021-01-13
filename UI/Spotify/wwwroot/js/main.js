function ProfileShow(){
	$("#profile").css('display','block');
}

function RegShow(){
	$("#profile-reg").css('display','flex');
}

function ProfileHide(){
    $("#profile").css('display','none');
}

$(document).mouseup(function (e){
	var profile_back = $("#profile");
	var profile_window = $(".profile__window");
	
	if (!profile_window.is(e.target) && profile_window.has(e.target).length === 0){
		profile_back.css('display','none');
	}
});

$(document).mouseup(function (e){
	var reg_back = $("#profile-reg");
	var reg_window = $(".profile-reg__window");

	if (!reg_window.is(e.target) && reg_window.has(e.target).length === 0){
		reg_back.css('display','none');
	}
});

$(document).ready(function(){
    // ProfileHide();
});

