# in-memory-cache
Performance usando memory cache.

# Consistência: 
Ao usar um cache em processo, seus elementos de cache são locais para uma única instância de seu aplicativo. No entanto, muitos aplicativos de médio a grande porte não terão uma única instância de aplicativo, pois provavelmente terão equilíbrio de carga. Nesse cenário, você terá tantos caches quanto as instâncias do aplicativo, cada um com um estado diferente, resultando em inconsistência. O estado pode, no entanto, ser eventualmente consistente, conforme o tempo limite dos itens em cache ou são despejados de todas as instâncias de cache.

Se você estiver armazenando em cache objetos imutáveis, a consistência deixa de ser um problema. Nesse caso, um cache em processo é uma escolha melhor, pois muitas sobrecargas normalmente associadas a caches externos distribuídos simplesmente não estão lá. Se seu aplicativo for implementado em vários nós, você armazenará objetos mutáveis em cache e desejará que suas leituras sejam sempre consistentes, em vez de, eventualmente, consistentes, um cache distribuído é o caminho a ser seguido.

# Overheads:
Um cache em processo pode afetar negativamente o desempenho de um aplicativo com um cache incorporado, principalmente devido a sobrecargas de coleta de lixo. Seus resultados, no entanto, dependem muito de fatores como o tamanho do cache e a rapidez com que os objetos estão sendo despejados e expirados.
Se você estiver procurando por um estado de cache global sempre consistente em uma implantação de vários nós, este cache não é o melhor caminho.

# Confiabilidade
Um cache em processo faz uso do mesmo espaço de heap que seu programa, portanto, é preciso ter cuidado ao determinar os limites superiores de uso de memória para o cache. Se o seu programa ficar sem memória, não há maneira fácil de se recuperar dele.
Um cache em processo parece ser uma opção melhor para um número pequeno e previsível de objetos frequentemente acessados, de preferência imutáveis.

# Recomendação
Para um número pequeno e previsível de objetos de preferência imutáveis que precisam ser lidos várias vezes, um cache em processo é uma boa solução, porque ele terá um desempenho melhor do que um cache distribuído.

# Processamento

Foi utilizado este código abaixo para simular o tempo de resposta de um serviço:
<img src="https://github.com/nogueirawagner/in-memory-cache/blob/master/Results/Processamento.jpg" alt="" />

# Resultados:

<table style="float: left;">
<tbody>
<tr>
<td>
<h1><strong>GetOrCreate</strong></h1>
<h3 style="padding-left: 30px;"><span style="color: #ff0000;">Sem Cache - Tempo: 1313 ms</span></h3>
<p style="padding-left: 30px;"><img src="https://github.com/nogueirawagner/in-memory-cache/blob/master/Results/GetOrCreate.jpg" alt="" /></p>
<h3 style="padding-left: 30px;"><span style="color: #00ff00;">Com Cache - Tempo: 237 ms</span></h3>
<p style="padding-left: 30px;"><img src="https://github.com/nogueirawagner/in-memory-cache/blob/master/Results/GetOrCreate_2.jpg" alt="" /></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
</td>
</tr>
<tr>
<td><h1><strong>GetOrCreateAsync</strong></h1>
<h3 style="padding-left: 30px;"><span style="color: #ff0000;">Sem Cache - Tempo: 464 ms</span></h3>
<p style="padding-left: 30px;"><img src="https://github.com/nogueirawagner/in-memory-cache/blob/master/Results/GetOrCreateAsync.jpg" alt="" /></p>
<h3 style="padding-left: 30px;"><span style="color: #00ff00;">Com Cache - Tempo: 184 ms</span></h3>
<p style="padding-left: 30px;"><img src="https://github.com/nogueirawagner/in-memory-cache/blob/master/Results/GetOrCreateAsync_2.jpg" alt="" /></p>
<p>&nbsp;</p>
<p>&nbsp;</p></td>
</tr>
<tr>
<td><h1><strong>TryGetValue</strong></h1>
<h3 style="padding-left: 30px;"><span style="color: #ff0000;">Sem Cache - Tempo: 1013 ms</span></h3>
<p style="padding-left: 30px;"><img src="https://github.com/nogueirawagner/in-memory-cache/blob/master/Results/TryGetValue.jpg" alt="" /></p>
<h3 style="padding-left: 30px;"><span style="color: #00ff00;">Com Cache - Tempo: 137 ms</span></h3>
<p style="padding-left: 30px;"><img src="https://github.com/nogueirawagner/in-memory-cache/blob/master/Results/TryGetValue_2.jpg" alt="" /></p>
<p>&nbsp;</p>
<p>&nbsp;</p></td></td>
</tr>
</tbody>
</table>
 
 Fonte: https://dzone.com/articles/process-caching-vs-distributed
