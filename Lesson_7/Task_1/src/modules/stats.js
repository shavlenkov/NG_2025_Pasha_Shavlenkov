import { getItemFromLocalStorage, setItemToLocalStorage } from "./localStorage.js";

const STATS_KEY = 'quiz_stats';

export function loadStats() {
    return JSON.parse(getItemFromLocalStorage(STATS_KEY) || {
        correct: 0,
        incorrect: 0,
        skipped: 0,
    });
}

export function saveStats(stats) {
    setItemToLocalStorage(STATS_KEY, JSON.stringify(stats))
}