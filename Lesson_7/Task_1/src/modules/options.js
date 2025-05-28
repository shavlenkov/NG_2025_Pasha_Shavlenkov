import { loadStats, saveStats } from "./stats.js";
import { renderQuiz } from "./quiz.js";

export function createOption(text, isCorrect, optionsContainer) {
    const stats = loadStats();

    const button = document.createElement('button');

    button.textContent = text;
    button.className = 'option';
    button.onclick = async () => {
        if (isCorrect) {
            stats.correct++;
        } else {
            stats.incorrect++;
        }

        saveStats(stats);

        await renderQuiz();
    };

    optionsContainer.appendChild(button);
}