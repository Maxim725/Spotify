let position = {};
$( ".album-list" ).each(function( index ) {
	position[`${this.id}`] = 0;
});
const albumsToShow = screen.width > 1024 ? 6 : 5;
const albumsToScroll = screen.width > 1024 ? 3 : 2;

const setPosition = (id) => {
	$(`#${id}.album-list`).css({
		transform: `translateX(${position[`${id}`]}px)`
	});
};

const checkButtons = (id) => {
	const album = $(`#${id}.album`);
	const albumsCount = album.length;
	const albumWidth = album.width() + parseInt(album.css("margin-right"));
	const btnPrev = $(`#${id}.album-list__prev-button`);
	const btnNext = $(`#${id}.album-list__next-button`);

	if (position[`${id}`] <= -(albumsCount - albumsToShow) * albumWidth) 
		btnNext.hide()
	else btnNext.show()
	
	if (position[`${id}`] === 0) 
		btnPrev.hide()
	else btnPrev.show()
};

function btnNextTap(id){
	const album = $(`#${id}.album`);
	const albumsCount = album.length;
	const albumWidth = album.width() + parseInt(album.css("margin-right"));
	const movePosition = albumsToScroll * albumWidth;

	const albumsLeft = albumsCount - (Math.abs(position[`${id}`]) + albumsToShow * albumWidth) / albumWidth;
	position[`${id}`] -= albumsLeft >= albumsToScroll ?  movePosition : albumsLeft * albumWidth;

	setPosition(id);
	checkButtons(id)
}

function btnPrevTap(id){
	const album = $('.album');
	const albumWidth = album.width() + parseInt(album.css("margin-right"));
	const movePosition = albumsToScroll * albumWidth;

	const albumsLeft = Math.abs(position[`${id}`]) / albumWidth;
	position[`${id}`] += albumsLeft >= albumsToScroll ?  movePosition : albumsLeft * albumWidth;

	setPosition(id);
	checkButtons(id)
}