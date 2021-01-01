class AudioPlayer {
    constructor () {
        this.audioElement = null;
        this.currentSource = null;
        this.isPaused = true;
        this.canPlay = false;
        this.volume = 1.0;
        this.queue = [];
    }

    /**
     * Начинает проигрывание нового трека.
     * @param {string} newSource новый источник воспроизведения.
     */
    play (newSource) {
        this.currentSource = newSource;
        this.canPlay = true;
        this.isPaused = false;

        if (this.audioElement) this.audioElement.remove();

        this.audioElement = document.createElement('audio');
        this.audioElement.src = this.currentSource;
        this.audioElement.volume = this.volume;
        this.audioElement.play();

        this.audioElement.onended = function (ev) {
            if (this.queue.length) {
                this.play(this.queue.shift());
            } else {
                this.canPlay = false;
                this.isPaused = true;
            }
        }
    }

    /**
     * Ставит воспроизведение на паузу.
     */
    pause () {
        if (this.audioElement) audioElement.pause();
        this.isPaused = true;
    }

    /**
     * Устанавливает громкость от 0 до 1.
     * @param {number} newVolume новая громкость.
     */
    setVolume(newVolume) {
        this.volume = Math.Max(0, Math.Min(1, newVolume));
        if (this.audioElement) this.audioElement.volume = this.volume;
    }

    /**
     * Устанавливает время трека на указанный процент.
     * @param {any} newTime новое время от 0 до 1.
     */
    seTime(newTime) {
        newTime = Math.Max(0, Math.Min(1, newTime));
        if (this.audioElement) this.audioElement.currentTime = Math.round(this.audioElement.duration * newTime);
    }

    /**
     * Добавить трек в очередь.
     * @param {string} source источник вопроизведения.
     */
    addToQueue (source) {
        this.queue.push(source);
        return this.queue.length - 1;
    }

    /**
     * Удаляет i-ый трек из очереди.
     * @param {number} i номер трека в очереди.
     */
    removeFromQueue(i) {
        return this.queue.splice(i, 1);
    }
}

window.player = new AudioPlayer();
