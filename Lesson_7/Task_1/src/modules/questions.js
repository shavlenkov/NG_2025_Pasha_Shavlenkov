export function generateQuestion(characters, difficulty) {
    const correctCharacter = characters[0];

    let question = '',
        correctAnswer = '';

    const options = characters.map(character => {
        switch (difficulty) {
            case 'easy': return character.name;
            case 'medium': return character.status;
            case 'hard': return character.species;
            default: return character.name;
        }
    });

    switch (difficulty) {
        case 'easy':
            question = `What is the name of this character?`;
            correctAnswer = correctCharacter.name;

            break;
        case 'medium':
            question = `What is the status of this character?`;
            correctAnswer = correctCharacter.status;

            break;
        case 'hard':
            question = `What species is this character?`;
            correctAnswer = correctCharacter.species;

            break;
        default:
            question = `What is the name of this character?`;
            correctAnswer = correctCharacter.name;
    }

    return { correctCharacter, question, correctAnswer, options };
}