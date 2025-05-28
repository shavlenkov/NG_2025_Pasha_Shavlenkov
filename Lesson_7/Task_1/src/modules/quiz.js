import { getRandomCharacters } from './api.js';
import { loadStats, saveStats }from './stats.js';
import { createOption } from './options.js';
import { generateQuestion } from "./questions.js";

let currentCorrectAnswer = null,
    currentDifficulty = 'easy';

export async function renderQuiz() {
    const stats = loadStats();

    const app = document.getElementById('app');

    app.innerHTML = '<p>Loading...</p>';

    const characters = await getRandomCharacters();
    const {
        correctCharacter,
        question,
        correctAnswer,
        options } = generateQuestion(characters, currentDifficulty);

    currentCorrectAnswer = correctAnswer;

    app.innerHTML = `
        <div class="quiz">
            <h1 class="quiz__title">Rick & Morty Quiz</h1>
            <div class="quiz__difficulty">
                Difficulty:
                <select class="quiz__select" id="difficulty">
                    <option value="easy" ${currentDifficulty === 'easy' ? 'selected' : ''}>Easy</option>
                    <option value="medium" ${currentDifficulty === 'medium' ? 'selected' : ''}>Medium</option>
                    <option value="hard" ${currentDifficulty === 'hard' ? 'selected' : ''}>Hard</option>
                </select>
            </div>
            <img src="${correctCharacter.image}" alt="Character" class="quiz__image" />
            <p class="quiz__question">${question}</p>
            <div class="quiz__options"></div>
            <div class="quiz__controls">
                <button class="quiz__button" id="quiz-button-skip">Skip</button>
                <button class="quiz__button" id="quiz-button-new">New</button>
            </div>
            <div class="quiz__stats">
                Correct: ${stats.correct} | Incorrect: ${stats.incorrect} | Skipped: ${stats.skipped}
            </div>
        </div>
    `;

    const optionsContainer = app.querySelector('.quiz__options');
    const shuffled = [...options].sort(() => Math.random() - 0.5);

    shuffled.forEach(opt => createOption(opt, opt === correctAnswer, optionsContainer));

    document.getElementById('quiz-button-skip').onclick = async () => {
        stats.skipped++;

        saveStats(stats);

        await renderQuiz();
    };

    document.getElementById('quiz-button-new').onclick = async () => await renderQuiz();

    document.getElementById('difficulty').onchange = async (event) => {
        currentDifficulty = event.target.value;

        await renderQuiz();
    };
}