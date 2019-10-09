mport pygame, sys
from pygame.locals import *
import random


pygame.init()
global ponto

ponto = 0

estados = "jogando"

#estados =" menu"


largura = 800			#variavel para largura e altura da tela do jogo
altura = 600

DISPLAY = pygame.display.set_mode((largura, altura))	#setando a tela do jogo
pygame.display.set_caption("hello wolrd")				#nome do jogo mostrado no centro da margem

x = 500
y = 200
yNav = y - 5
xNav = x + 40
velX = 0			#setando a velocidade que será utilizada na nave
velY = 0
cinza = (100, 100, 100)


#carregando as imagens da nave e o retangulo "invisivel" que ficará em volta da nave para coisões
nave = Rect((x,y),(100,160))
tiro = Rect((xNav,yNav),(10,20))
naveFrente = pygame.image.load('frente.jpeg');
naveDireito = pygame.image.load('Ldireito.jpeg');
naveEsquerdo = pygame.image.load('lEsquerdo.jpeg');
meteoro = pygame.image.load('Meteoro.jpeg');
naveF = pygame.transform.scale(naveFrente,(100, 160))
naveD = pygame.transform.scale(naveDireito,(100, 160))		#alterando o tamanho da imagem
naveE = pygame.transform.scale(naveEsquerdo,(100, 160))
meteoroEsc = pygame.transform.scale(meteoro,(100, 160))
meteoroRot= pygame.transform.rotate(meteoroEsc,  -100 )


relogio = pygame.time.Clock()

FPS=30

pygame.font.init()
font_padrao = pygame.font.get_default_font()
font_pontos = pygame.font.SysFont (font_padrao, 20)
pontos = pygame.font.SysFont (font_padrao, 20)



def objetos(objetoX, objetoY, objetoLar, objetoAlt, color):	
	pygame.draw.rect(DISPLAY, color, [objetoX, objetoY, objetoLar, objetoAlt])
	global ponto
	#função para criar os objetos de colisão aleatórios
	DISPLAY.blit(meteoroRot, (objetoX, objetoY))
	if (objetoY == altura):
			ponto +=1



numNave = 0

objetoStartx = random.randrange(0, largura)		#setando posições aleatórias de inicio dos objetos de colisao
objetoStarty = -600
objetoVel = 15			#velocidade do objeto de colisão
objetoLar = 0			#largura e altura dos objetos
objetoAlt = 0





sair = True
while sair:
	DISPLAY.fill((255,255,255))
	if  estados == "menu":
		iniciar = Rect((largura/2, altura/3), largura - (largura - 100), altura - (altura-50))
		pygame.draw.rect(DISPLAY, (255,0,0), iniciar)
		mouse_x, mouse_y = pygame.mouse.get_pos()
		for even in pygame.event.get():
			if even.type == pygame.MOUSEBUTTONDOWN:
				if mouse_x > (0) or mouse_x >(800):
					estados = "jogando"




	if estados == "jogando":
		
		pont = str(ponto)
		p = "pontos:"
		text = font_pontos.render(p,1, (0,0,0))
		pts = pontos.render(pont,1,(0,0,0))
		DISPLAY.blit(pts,(largura - (largura - 102),altura - (altura - 20)))
		DISPLAY.blit(text, (largura - (largura - 50),altura - (altura-20)))
		
		
		
		
		#pygame.draw.rect(DISPLAY,( 0, 0, 0), nave)		#este item que estava criando o bloco preto
		if (numNave == 1):
			DISPLAY.blit(naveD,(x,y));

		elif(numNave == 2):
			DISPLAY.blit(naveE,(x,y));
			
		elif(numNave == 0):
			DISPLAY.blit(naveF,(x,y));

		if x > largura -100 or x == 0:		#definindo o limite das margens da tela
			velX = 0

		if objetoStarty > altura:			#
			objetoStarty = 0 - objetoLar
			objetoStartx = random.randrange(0, largura)
		if y < objetoStarty+objetoAlt:
			#print("ultrapassou")

			if x > objetoStartx and x < objetoStartx + objetoLar or x+100 > objetoStartx and x+100 < objetoStartx+objetoLar:
				ponto  = 0
				print("x crossover")				#setando a colisão


		for event in pygame.event.get():		#setando o click do mouse para fechar o jogo
			if event.type==QUIT:
				sair = False
				sys.exit()
			
			if event.type == pygame.KEYDOWN:		#tecla de movimentação para a direita
				if event.key == pygame.K_RIGHT:
					numNave = 1
					velX = 8
					
				elif event.key == pygame.K_LEFT:		#tecla de movimentação para a esquerda
					numNave = 2
					velX= -8


			if event.type == pygame.KEYDOWN:			#tecla de movimentação para baixo
				if event.key == pygame.K_DOWN:
					numNave = 0
					velY = 8
			if event.type == pygame.KEYDOWN:			#tecla de movimentação para cima
				if event.key == pygame.K_UP:
					numNave = 0
					velY = -8

				elif event.key == pygame.K_SPACE:		#tecla de espaço para atirar , não funcional
					if (yNav==0):
						pygame.draw.rect(DISPLAY,( 255, 255, 0), tiro)
						yNav+=5

			if event.type == pygame.KEYUP:			#parar a movimentação quando não houver mais tecla pressionada
				if event.key == pygame.K_LEFT or event.key == pygame.K_RIGHT:
					numNave = 0
					velX = 0
				if event.key == pygame.K_DOWN or event.key == pygame.K_UP:
					velY = 0


		x+= velX
		y+= velY

		objetos(objetoStartx, objetoStarty, objetoLar, objetoAlt, cinza)	#chamando os atributos do objeto de colisão
		objetoStarty += objetoVel
		
		
		pygame.display.update()
		relogio.tick(FPS)
	
pygame.quit()


