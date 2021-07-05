import { StatusBar } from 'expo-status-bar';
import React, { Component } from 'react';
import { Image,ImageBackground, StyleSheet, Text, TextInput, TouchableOpacity, View } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { LinearGradient } from 'expo-linear-gradient';
import api from '../services/api';



export default class Login extends Component{
  constructor(props){
    super(props);
    this.state = {
      email : '',
      senha : ''
    };
  }

  login = async () => {
    const resposta = await api.post('/Login', {
        email : this.state.email,
        senha : this.state.senha
    });

    const token = resposta.data.token;
    console.warn(token);

    await AsyncStorage.setItem('tokenUsuario', token);

    this.props.navigation.navigate('Home');
};

  render(){
      return (
        <View style={styles.main}>
        <LinearGradient
        colors={['#AEE8E6','#FFFFFF']}
        style={styles.background}>

          <Image 
            source={require('../../assets/img/logo_spmedgroup_v2.png')}
            style={styles.mainImgLogin}/>

          <TextInput 
            style={styles.inputLogin}
            placeholder='username'
            keyboardType='email-address'
            onChangeText={email => this.setState({ email })}/>

          <TextInput 
              style={styles.inputLogin}
              placeholder='password'
              secureTextEntry={true}
              onChangeText={senha => this.setState({ senha })}/>

          <TouchableOpacity
              style={styles.btnLogin}
              onPress={this.login}>
              <Text style={styles.btnLoginText}>Entrar</Text>
          </TouchableOpacity>
          </LinearGradient>
        </View>
      );
  }
}

const styles = StyleSheet.create({
  main: {
    width: '100%',
    height: '100%'

  },

  background: {
    alignItems: 'center',
    justifyContent: 'center',
    width : '100%',
    height : '100%',
  },

  mainImgLogin: {
    height: 83,
    width: 74,
    margin: 60,
    marginTop: 0
},

  inputLogin:{
    width: 240,
    height: 50,
    borderBottomWidth: 1,

  },

  btnLogin: {
    alignItems: 'center',
    justifyContent: 'center',
    height: 38,
    width: 240,
    backgroundColor: '#AEE8E6',
    borderRadius: 4,
    shadowOffset: { height: 2, width: 3 },
    marginTop: 15
},
});