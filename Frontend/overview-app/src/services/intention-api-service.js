import axios from "axios"

export class IntentionApiService {
  constructor() {
    this.httpService = axios.create({
      baseURL: "https://localhost:7098/api",
      headers: {
        'Content-Type': 'application/json'
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
      console.error(error)
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
}
