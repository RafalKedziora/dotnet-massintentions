export class CookieService {
  static getCookies() {
    const entries = document.cookie
      .split(';')
      .map(x => x.trim().split('='))

    return Object.fromEntries(entries)
  }

  static getSessionToken() {
    return this.getCookies()['USER_SESSION']
  }

  static setCookie(prop, value, daysExpiring = 1) {
    const MILLISECONDS_IN_DAY = 24 * 60 * 60 * 1000
    const date = new Date()

    date.setTime(date.getTime() + (daysExpiring * MILLISECONDS_IN_DAY))
    document.cookie = `${prop}=${value}; expires=${date.toUTCString()}; path=/`
  }

  static deleteCookie(prop) {
    document.cookie = `${prop}=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/`;
  }
}