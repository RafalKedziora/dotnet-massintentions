import axios from "axios"
import { CookieService } from "@/services/cookie-service"

export class ApiService {
  constructor() {
    this.httpService = axios.create({
      baseURL: "https://localhost:7098/api",
      headers: {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
        'Authorization': `Bearer ${CookieService.getSessionToken()}`,
        'Accept': 'application/json'
      }
    })
  }

  async getAllIntentions() {
    try {
      const { data, headers } = await this.httpService.get(`/Intention`)
      return [null, data, { headers }]
    }
    catch (error) {
      console.error(error)
      return [error, error.response?.status]
    }
  }

  async getIntentionById(id) {
    try {
      const { data, headers } = await this.httpService.get(`/Intention/${id}`)
      return [null, data, { headers }]
    }
    catch (error) {
      console.error(error)
      return [error, error.response?.status]
    }
  }

  async getCategories() {
    try {
      const { data, headers } = await this.httpService.get(`/Categories`)
      return [null, data, { headers }]
    }
    catch (error) {
      return [error, error.response?.status]
    }
  }

  async addIntention(updateModel) {
    try {
      const { data, headers } = await this.httpService.post(
        `/Intention`,
        updateModel
      )
      return [null, data, { headers }]
    }
    catch (error) {
      console.error(error)
      return [error, error.response?.status]
    }
  }

  async updateIntention(id, updateModel) {
    try {
      const { data, headers } = await this.httpService.put(
        `/Intention/${id}`,
        updateModel
      )
      return [null, data, { headers }]
    }
    catch (error) {
      console.error(error)
      return [error, error.response?.status]
    }
  }

  async deleteIntention(id) {
    try {
      const { data, headers } = await this.httpService.delete(
        `/Intention/${id}`,
      )
      return [null, data, { headers }]
    }
    catch (error) {
      console.error(error)
      return [error, error.response?.status]
    }
  }

  async addCategory(model) {
    try {
      const { data, headers } = await this.httpService.post(
        `/Categories`,
        model
      )
      return [null, data, { headers }]
    }
    catch (error) {
      console.error(error)
      return [error, error.response?.status]
    }
  }

  async register(model) {
    try {
      const { data, headers } = await this.httpService.post(
        `/Account/Register`,
        model
      )
      return [null, data, { headers }]
    }
    catch (error) {
      console.error(error)
      return [error, error.response?.status]
    }
  }

  async login(model) {
    try {
      const { data, headers } = await this.httpService.post(
        `/Account/Login`,
        model
      )
      return [null, data, { headers }]
    }
    catch (error) {
      console.error(error)
      return [error, error.response?.status]
    }
  }

  async getRoleByEmail(email) {
    try {
      const { data, headers } = await this.httpService.get(`/Account/Role/?email=${email}`)
      return [null, data, { headers }]
    }
    catch (error) {
      console.error(error)
      return [error, error.response?.status]
    }
  }
}
