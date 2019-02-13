import axios from "axios"

export const checkExam = (examId) => {
  console.log(examId)
  axios
    .put(`/api/v1/students/263aa508-4c70-4920-bc49-94837057d264/exams/${examId}`)
    .then(result => {
      console.log(result)
    })
    .catch(error => {
      console.log(error)
    });

};