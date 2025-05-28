export function getItemFromLocalStorage(key) {
    return localStorage.getItem(key);
}

export function setItemToLocalStorage(key, value) {
    localStorage.setItem(key, value);
}