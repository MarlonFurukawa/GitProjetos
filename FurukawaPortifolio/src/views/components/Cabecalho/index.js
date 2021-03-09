import React from 'react';
import { View, StyleSheet, Image, Text } from 'react-native';

const Cabecalho = () => {
    return (<>
        <View style={styles.containerTitulo}>
            <Text style={styles.titulo}>Marlon Furukawa</Text>
            <View>
                <Image
                    source={require('../../../assets/images/IMG_20210122_204235.jpg')}
                    style={styles.imagem}
                />
            </View>
        </View>
        <View style={styles.containerDescricao}>
            <View style={styles.containerSeparador} />
            <View style={styles.containerTexto}>
                <Text style={styles.TextoDescricao} >Analista Desenvolvedor</Text>
            </View>
        </View>
    </>
    );
};

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#3b0099',
    },
    containerTitulo: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        alignItems: 'center',
        paddingHorizontal: 24,
    },
    containerDescricao: {
        paddingHorizontal: 23,
    },
    containerSeparador: {
        borderWidth: 0.5,
        borderColor: '#A1A5AA'
    },
    containerTexto: {
        flexDirection: 'row',
        justifyContent: 'center',
        marginTop: -13
    },
    titulo: {
        fontFamily: 'OpenSans-ExtraBold',
        fontSize: 28,
    },
    TextoDescricao: {
        backgroundColor: '#3b0099',
        fontSize: 16,
        fontFamily: 'OpenSans-Regular',
    },
    imagem: {
        height: 50,
        width: 50,
        borderRadius: 50,
    },
})

export default Cabecalho;