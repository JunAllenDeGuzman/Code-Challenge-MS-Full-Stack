import './App.css';
import axios from "axios";
import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function App() {
  const baseURL = process.env.REACT_APP_API_END_POINT;
  const [outputFilename, setOutputFilename] = useState("");
  const [inputFilename, setInputFilename] = useState("");
  const [directoryPath, setDirectoryPath] = useState("");

  function GetStudentInfo(directoryPath, inputFilename, outputFilename) {
    return axios.get(`${baseURL}SchoolStudentInfo/GetUserInfo?directoryPath=${directoryPath}&inputFilename=${inputFilename}&outputFilename=${outputFilename}`);
  }

  const handleFileChange = (event) => {
    setInputFilename(event.target.files[0].name);
  };

  const upload = () => {
    GetStudentInfo(directoryPath, inputFilename, outputFilename)
      .then((response) => {
        toast.success("Sucessfully uploaded")
        setDirectoryPath("")
        setInputFilename("")
        setOutputFilename("")

      })
      .catch((error) => {
        console.error('Error fetching student info:', error);
        toast.error("Failed to upload")
      })
  }

  return (
    <div className="App">
      <ToastContainer />
      <Form>
        <Form.Group className="mb-3" controlId="filePath">
          <Form.Label>File Path:</Form.Label>
          <Form.Control type="text" placeholder="File Path" required value={directoryPath} onChange={(e) => setDirectoryPath(e.target.value)} />
        </Form.Group>

        <Form.Group className="mb-3" controlId="outputFileName" required>
          <Form.Label>Output File Name:</Form.Label>
          <Form.Control type="text" placeholder="Output File Name" value={outputFilename} onChange={(e) => setOutputFilename(e.target.value)} />
        </Form.Group>

        <Form.Group className="mb-3" controlId="chooseFile">
          <Form.Label>Choose File:</Form.Label>
          <Form.Control type="file" required onChange={handleFileChange} />
        </Form.Group>

        <Button onClick={upload}>Submit</Button>
      </Form>
    </div>
  );
}

export default App;