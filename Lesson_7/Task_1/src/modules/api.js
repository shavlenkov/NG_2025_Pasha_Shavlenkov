const API_URL = "https://rickandmortyapi.com/api";
const MAX_ID = 826;

export async function getRandomCharacters(count = 4) {
    const ids = [];

    while (ids.length < count) {
        const randomId = Math.floor(Math.random() * MAX_ID) + 1;

        if (!ids.includes(randomId)) {
            ids.push(randomId);
        }
    }

    const response = await fetch(`${API_URL}/character/${ids.join(',')}`);
    const data = await response.json();

    return Array.isArray(data) ? data : [data];
}