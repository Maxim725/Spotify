class QueueTrack {
	constructor () {
		this.id = 0;
		this.title = '';
		this.cover = '';
		this.album = '';
		this.url = '';
		this.artist = '';
		this.artistUrl = '';
	}
}

class Player {
	constructor () {
		this.isPaused = true;
		this.canPlay = false;
		this.volume = 0.5;

		this.current = {
			title: "",
			url: "#",
			cover: "/data/album-cover/0",
			album: "#",
			artist: {
				name: "",
				url: "#"
			}
		}

		this.queue = [];
		this.queuePosition = 0;

		this.player = document.createElement('audio');

		this.progressElement = null;
		this.timeStampLeft = null;
		this.timeStampRight = null;

		setInterval(() => {
			updateProgress();
		}, 100);

		const updateProgress = () => {
			if (!this.isPaused
				&& this.progressElement
				&& this.timeStampLeft
				&& this.timeStampRight) {
					this.progressElement.value = (this.player.currentTime / this.player.duration) * 100;
					this.timeStampLeft.innerText = this.secsToStamp(this.player.currentTime? this.player.currentTime : 0);
					this.timeStampRight.innerText = this.secsToStamp(this.player.duration? this.player.duration : 0);
			}

			if (!this.progressElement || !document.body.contains(this.progressElement)) {
				this.trySync();
			}
		}
	}

	init() {
		this.bindVolume();
	}

	clearQueue() {
		this.queue = [];
	}

	setQueue(i) {
		this.queuePosition = i;
	}

	addQueue(i) {
		this.queue.push(i);
	}

	trySync() {
		this.bindProgress();
		this.updateTrack();

		let $volumeInput = document.querySelector('.player__volume input[type="range"]');

		if ($volumeInput) {
			$volumeInput.value = this.volume * 100;
		}

		let $playButtonImage = document.querySelector('.player__play-button img');

		if ($playButtonImage) {
			this.isPaused? $playButtonImage.src = '/images/icons/footer_play.svg' : $playButtonImage.src = '/images/icons/footer_pause.svg'
		}

		if (this.progressElement) this.progressElement.value = (this.player.currentTime / this.player.duration) * 100;
		if (this.timeStampLeft) this.timeStampLeft.innerText = this.secsToStamp(this.player.currentTime? this.player.currentTime : 0);
	}

	/**
	 * Update track in player.
	 * @param {QueueTrack} track track.
	 */
	play(track) {
		this.current.title = track.title;
		this.current.url = track.url;
		this.current.album = track.album;
		this.current.cover = track.cover;
		this.current.artist.name = track.artist;
		this.current.artist.url = track.artistUrl;
		
		this.player.volume = this.volume;
		this.player.src = track.url;
		this.player.play();
		this.isPaused = false;

		this.player.onloadedmetadata = () => {
			let $trackTimeStamp = document.querySelector('.player__time-left');

			if ($trackTimeStamp) {
				$trackTimeStamp.innerText = this.secsToStamp(this.player.duration);
			}
		}

		this.player.onended = () => {
			if (this.queuePosition < this.queue.length) {
				this.play(this.queue[++this.queuePosition])
			} else {
				this.isPaused = true;
				this.trySync();
			}
		}

		this.trySync();
	}

	updateTrack() {
		let $albumLink = document.querySelector('.player__left-side a');
		let $trackCover = document.querySelector('.player__left-side a img');
		let $trackTitle = document.querySelector('.player__track-title');
		let $artistName = document.querySelector('.player__track-artist');

		if ($albumLink) $albumLink.href = this.current.album;
		if ($trackCover) $trackCover.src = this.current.cover;

		if ($trackTitle) {
			$trackTitle.innerText = this.current.title;
			$trackTitle.href = this.current.album;
		}

		if ($artistName) {
			$artistName.innerText = this.current.artist.name;
			$artistName.href = this.current.artist.url;
		}
	}

	secsToStamp(s) {
		s = Math.floor(s);
		let m = Math.floor(s / 60);
		s -= m * 60;
		return `${m}:${('0' + s).slice(-2)}`
	}

	updateVolume(newVol) {
		newVol = Math.max(Math.min(1, newVol), 0);
		this.volume = newVol;
		this.player.volume = this.volume;
	}

	bindVolume() {
		let $volumeInput = document.querySelector('.player__volume input[type="range"]');

		if ($volumeInput) $volumeInput.addEventListener('change', (ev) => {
			this.updateVolume($volumeInput.value / 100);
		});
	}

	_bindVolume() {
		let $volumeInput = document.querySelector('.player__volume input[type="range"]');
		if ($volumeInput) this.updateVolume($volumeInput.value / 100);
	}

	bindProgress() {
		let $trackProgress = document.querySelector('.player__track-progress');
		let $trackTimeStampPassed = document.querySelector('.player__time-passed');
		let $trackTimeStampDuration = document.querySelector('.player__time-left');

		if ($trackProgress) this.progressElement = $trackProgress;
		if ($trackTimeStampPassed) this.timeStampLeft = $trackTimeStampPassed;
		if ($trackTimeStampDuration) this.timeStampRight = $trackTimeStampDuration;
	}

	_bindProgress() {
		let $trackProgress = document.querySelector('.player__track-progress');

		if ($trackProgress) this.player.currentTime = $trackProgress.value / 100 * this.player.duration;
	}

	_bindPlay() {
		let $playButtonImage = document.querySelector('.player__play-button img');

		if ($playButtonImage) {
			this.isPaused = !this.isPaused;
			this.isPaused? this.player.pause() : this.player.play();

			this.isPaused? $playButtonImage.src = '/images/icons/footer_play.svg' : $playButtonImage.src = '/images/icons/footer_pause.svg'
		}
	}
	
	_goNext() {
		if (this.queuePosition < this.queue.length) {
			this.play(this.queue[++this.queuePosition]);
		}
	}

	_goPrevious() {
		if (this.queuePosition > 0) {
			this.play(this.queue[--this.queuePosition]);
		}
	}
}

window.player = new Player();
window.player.init();
