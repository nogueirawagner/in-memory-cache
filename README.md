# in-memory-cache
Performance usando memory cache:

# Consistência: 
Ao usar um cache em processo, seus elementos de cache são locais para uma única instância de seu aplicativo. No entanto, muitos aplicativos de médio a grande porte não terão uma única instância de aplicativo, pois provavelmente terão equilíbrio de carga. Nesse cenário, você terá tantos caches quanto as instâncias do aplicativo, cada um com um estado diferente, resultando em inconsistência. O estado pode, no entanto, ser eventualmente consistente, conforme o tempo limite dos itens em cache ou são despejados de todas as instâncias de cache.

# Overheads:
Um cache em processo pode afetar negativamente o desempenho de um aplicativo com um cache incorporado, principalmente devido a sobrecargas de coleta de lixo. Seus resultados, no entanto, dependem muito de fatores como o tamanho do cache e a rapidez com que os objetos estão sendo despejados e expirados.

# Confiabilidade
Um cache em processo faz uso do mesmo espaço de heap que seu programa, portanto, é preciso ter cuidado ao determinar os limites superiores de uso de memória para o cache. Se o seu programa ficar sem memória, não há maneira fácil de se recuperar dele.

<table style="float: left;">
<tbody>
<tr>
<td>
<h1><strong>GetOrCreate</strong></h1>
<h3 style="padding-left: 30px;"><span style="color: #ff0000;">Sem Cache</span></h3>
<p style="padding-left: 30px;"><img src="https://github.com/nogueirawagner/in-memory-cache/blob/master/Results/GetOrCreate.jpg" alt="" /></p>
<h3 style="padding-left: 30px;"><span style="color: #00ff00;">Com Cache</span></h3>
<p style="padding-left: 30px;"><img src="https://github.com/nogueirawagner/in-memory-cache/blob/master/Results/GetOrCreate_2.jpg" alt="" /></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
</td>
</tr>
<tr>
<td><h1><strong>GetOrCreateAsync</strong></h1>
<h3 style="padding-left: 30px;"><span style="color: #ff0000;">Sem Cache</span></h3>
<p style="padding-left: 30px;"><img src="https://github.com/nogueirawagner/in-memory-cache/blob/master/Results/GetOrCreateAsync.jpg" alt="" /></p>
<h3 style="padding-left: 30px;"><span style="color: #00ff00;">Com Cache</span></h3>
<p style="padding-left: 30px;"><img src="https://github.com/nogueirawagner/in-memory-cache/blob/master/Results/GetOrCreateAsync_2.jpg" alt="" /></p>
<p>&nbsp;</p>
<p>&nbsp;</p></td>
</tr>
<tr>
<td><h1><strong>TryGetValue</strong></h1>
<h3 style="padding-left: 30px;"><span style="color: #ff0000;">Sem Cache</span></h3>
<p style="padding-left: 30px;"><img src="https://github.com/nogueirawagner/in-memory-cache/blob/master/Results/TryGetValue.jpg" alt="" /></p>
<h3 style="padding-left: 30px;"><span style="color: #00ff00;">Com Cache</span></h3>
<p style="padding-left: 30px;"><img src="https://github.com/nogueirawagner/in-memory-cache/blob/master/Results/TryGetValue_2.jpg" alt="" /></p>
<p>&nbsp;</p>
<p>&nbsp;</p></td></td>
</tr>
</tbody>
</table>
 
 Fonte: https://dzone.com/articles/process-caching-vs-distributed
