import { getLocalStorageItem, setLocalStorageItem } from "./localStorage.js";

const STATS_KEY = 'quiz_stats';

export function loadStats() {
    return JSON.parse(getLocalStorageItem(STATS_KEY) || {
        correct: 0,
        incorrect: 0,
        skipped: 0,
    });
}

export function saveStats(stats) {
    setLocalStorageItem(STATS_KEY, JSON.stringify(stats))
}